    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(commandText, connection))
    {
        connection.Open();
        using (SqlDataReader reader = command.ExecuteReader()) 
        {
            while (reader.Read())
               // Do something with the rows
        }
    }
