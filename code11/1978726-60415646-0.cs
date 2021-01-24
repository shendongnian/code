            string connectionString = @"data source=WS-KIRON-01;initial catalog=MyCaseTestDb;integrated security=True;MultipleActiveResultSets=True";
    		using (var _connection = new SqlConnection(connectionString))
            {
                _connection.Open();
                using (SqlCommand command = new SqlCommand("create procedure prabhat @para varchar(255) as insert into LocalTestTable (name) values(@para)", _connection))
                {
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    sqlDataReader.Close();
                }
                _connection.Close();
    
            }
