     using(var connection = GetOdbcConnection())
        {
            connection.Open();
            using (var cmd = new OdbcCommand(query, connection))
            {
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    long textLen = reader.GetChars(0, 0, null, 0, 0);
                }
                reader.Close();
            }            
            // Close the connection
            connection.Close();
        }
