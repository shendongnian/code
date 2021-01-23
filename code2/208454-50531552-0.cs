    string connectionString = "Data Source=DESKTOP-2EV7CF4;Initial Catalog=TestDB;User ID=sa;Password=tintin11#";
    string queryString = "Select * from EMP";
    
    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                            }
                        }
                        reader.Close();
                    }
                }
