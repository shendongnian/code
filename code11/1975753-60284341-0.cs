    SqlDataReader reader = null;
         using (SqlConnection connection = new SqlConnection(_sqlConnectionStringFromUserImput))
                        {
                            connection.Open();
                            if (connection.State == ConnectionState.Open)
                            {
                                SqlCommand sqlCommand =
                                    new SqlCommand(
                                        "select count(*) from history",
                                        connection)
                                    {
                                        CommandType = CommandType.Text,
                                        CommandTimeout = 20
                                    };
                                reader = sqlCommand.ExecuteReader();
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        DateTime datetimefield = reader.GetFieldValue<DateTime>(0);
                                        string stringField = reader.GetFieldValue<string>(1);
                                    }
                                }
                                reader.Close();
            }
                            connection.Close();
                        }
