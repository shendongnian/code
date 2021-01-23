    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandText = "INSERT INTO table (column) VALUES (@param)";
    
        command.Parameters.AddWithValue("@param", value);
    
        connection.Open();
        command.ExecuteNonQuery();
    }
