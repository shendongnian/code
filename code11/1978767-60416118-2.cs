               string connectionString = @"data source=WS-KIRON-01;initial catalog=TestDatabase;integrated security=True;MultipleActiveResultSets=True";
               
    
                using (var _connection = new SqlConnection(connectionString))
                {
                    _connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO Employee (username,password)  VALUES (@username,@password)", _connection))
                    {
                        command.Parameters.AddWithValue("@username", "testuser");
                        command.Parameters.AddWithValue("@password", "pass");
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        sqlDataReader.Close();
                    }
                   
                    _connection.Close();
    
                }
