    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandText = commandText;
    
        connection.Open();
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                int id = (int)reader["ID"];
            }
        }
    }
