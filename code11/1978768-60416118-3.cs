                   string connectionString = @"data source=WS-KIRON-01;initial catalog=TestDatabase;integrated security=True;MultipleActiveResultSets=True";//Replace Your connection string
                   
        
                    using (var _connection = new SqlConnection(connectionString))
                    {
                        _connection.Open();
                        using (SqlCommand command = new SqlCommand("INSERT INTO Employee (username,password,city,phone)  VALUES (@username,@password,@city,@phone)", _connection))
                        {
                            command.Parameters.AddWithValue("@username", "testuser");
                            command.Parameters.AddWithValue("@password", "pass");
                            command.Parameters.AddWithValue("@city", "TestCity");
                            command.Parameters.AddWithValue("@phone", "TestPhone");
                            SqlDataReader sqlDataReader = command.ExecuteReader();
                            sqlDataReader.Close();
                        }
                       
                        _connection.Close();
        
                    }
