    string commandText = "SELECT MAX(Code) FROM Customer WHERE CustomerID = @ID;";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(commandText, connection);
        command.Parameters.AddWithValue("@ID", id); // e.g id is int = 23;
        try
        {
            connection.Open();
            var maxCode= command.ExecuteScalar();
            Console.WriteLine("Max: {0}", maxCode);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
