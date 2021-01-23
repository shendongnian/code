    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
    
        string selectCommand = "EXEC sp_YourStoredProcedure @whereClause";
    
        SqlCommand command = new SqlCommand(selectCommand, connection);
        command.Parameters.Add("@whereClause", System.Data.SqlDbType.NVarChar);
        command.Parameters["@whereClause"] = whereClause;
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.NextResult())
            {
                string location = reader.GetString(0);
                string partName = reader.GetString(1);
    
                // do something
            }
        }
    
        connection.Close();
    }
