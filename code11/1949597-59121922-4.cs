    using (SqlConnection connection = new SqlConnection(myConnString))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(fullSQLString, connection);
                        foreach (SqlParameter p in sqlParameters)
                            cmd.Parameters.Add(p);
                        cmd.ExecuteNonQuery();
                    }
