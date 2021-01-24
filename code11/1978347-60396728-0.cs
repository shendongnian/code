                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\msm.mdf;Connect Timeout=30;Integrated Security=True;";
              
                using (var _connection = new SqlConnection(connectionString))
                {
                    _connection.Open();
    
                    using (SqlCommand command = new SqlCommand("Insert into [LocalTestTable] values (@name,@description)", _connection))
                    {
                        command.Parameters.AddWithValue("@name", "TestFlatName");
                        command.Parameters.AddWithValue("@description", "TestFlatDescription");
                        SqlDataReader sqlDataReader = command.ExecuteReader();
                        sqlDataReader.Close();
                    }
                    _connection.Close();
    
                }
