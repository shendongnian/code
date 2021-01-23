    using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            // Declare Command
            OleDbCommand command = new OleDbCommand(YourSQL);
    
            // Set the Connection to the new OleDbConnection.
            command.Connection = connection;
    
            // Open the connection and execute the command.
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // The connection is automatically closed when the
            // code exits the using block.
         }
