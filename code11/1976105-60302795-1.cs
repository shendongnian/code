                using (SqlConnection connection = new SqlConnection(connectionString ))
                        {
                            connection.Open();
                            var queryText = "UPDATE TestTable SET fname = '" + requestPram.fname + "' WHERE rno ='" + requestPram.rno + "'";
    
                            using (SqlCommand cmd = new SqlCommand(queryText, connection))
                            {
                                responseResults = await cmd.ExecuteNonQueryAsync();
                            }
                            connection.Close();
    
                        }
