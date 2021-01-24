             using (SqlConnection connection = new SqlConnection(_sqlConnectionStringFromUserImput))
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
                                    DateTime datetimefield = reader.GetFieldValue<DateTime>(0);
                                    string stringField = reader.GetFieldValue<string>(1);
                                }
                            }
                            reader.Close();
        }
                        connection.Close();
                    }
