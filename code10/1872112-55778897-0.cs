private void SqlCommand (string connectionString, string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var a = reader[0];
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
        }
Or
using (var connection = ContextFactory.GetNewContextGeneric(connectionString).Database.GetDbConnection())
                {
                    connection.Open();
                    DbCommand command = connection.CreateCommand();
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader())
                    {
                        // Do something with result
                        reader.Read(); // Read first row
                        var firstColumnObject = reader.GetValue(0);
                        /*var secondColumnObject = reader.GetValue(1);
                        reader.Read(); // Read second row
                        firstColumnObject = reader.GetValue(0);
                        secondColumnObject = reader.GetValue(1);*/
                        connection.Close();
                        return firstColumnObject.ToString();
                    }
                }
