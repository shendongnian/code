             using (SqlConnection connection = new SqlConnection(_sqlConnectionString))
                            {
                                connection.Open();
                                if (connection.State == ConnectionState.Open)
                                {
                                    SqlCommand sqlCommand =
                                        new SqlCommand(
                                            "select id from utenti",
                                            connection)
                                        {
                                            CommandType = CommandType.Text,
                                            CommandTimeout = 20
                                        };
                                    SqlDataReader reader = sqlCommand.ExecuteReader();
                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            string stringField = reader.GetFieldValue<string>(0);
                                            //other possibilities for example if there was more columns and the next column in the row had datetime
                                            DateTime datetimefield = reader.GetFieldValue<DateTime>(1);
                                            
                                        }
                                    }
                                    reader.Close();
                }
                                connection.Close();
                            }
