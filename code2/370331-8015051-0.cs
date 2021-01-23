    string connectionString =  ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
    
    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = connection.CreateCommand())
    {
        command.CommandText = commandText;
        // command.Parameters.AddWithValue("@param", value);
    
        connection.Open();
        command.ExecuteNonQuery(); // or command.ExecuteScalar() or command.ExecuteRader()
    }
