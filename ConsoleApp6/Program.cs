using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter your message:");

        // Capture user input from the console
        string userInput = Console.ReadLine();

        // Store the entered message in the database
        StoreMessage(userInput);

        Console.WriteLine("Message stored in the database!");
        Console.ReadLine(); // Wait for Enter key to exit
    }

    static void StoreMessage(string message)
    {
        string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=YourDatabaseName;Integrated Security=True";

        ; // Replace with your actual connection string

        // SQL command to insert the message into the database
        string insertCommand = "INSERT INTO Messages (Message) VALUES (@Message)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(insertCommand, connection);
            command.Parameters.AddWithValue("@Message", message);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("Rows affected: " + rowsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
