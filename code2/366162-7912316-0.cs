    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand(strPreparedStatement, connection))
        {
            if (sqlParameters != null)
            {
                // If sqlParameter is an array, you can just use
                // command.Parameters.AddRange(sqlParameters) instead
                foreach (SqlParameter parameter in sqlParameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            using (SqlDataReader reader = command.ExecuteReader())
            {
                DataTable table = new DataTable();
                // Perform any extra initialization here
                table.Load(reader);
                return table;
            }
        }
    }
