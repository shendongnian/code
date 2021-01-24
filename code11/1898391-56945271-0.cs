    query = "SELECT * FROM dbo.Cat05Projects WHERE JobNumber = @JobNumber AND JobTag = @JobTag";
                    command = new SqlCommand(query, cn);
                    command.Parameters.AddWithValue("JobNumber", JobNumber);
                    command.Parameters.AddWithValue("JobTag", JobTag);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int i = 1; i < reader.FieldCount; i++)
                        {
                            lista.Add(reader[i].ToString());
                        }
                    }
