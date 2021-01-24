            string connectionString = @"data source=MS-KIRON-01;initial catalog=TestDatabase;integrated security=True;MultipleActiveResultSets=True";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
    
    
            String sql = "update TestTable set fname=@fname where rno =rno";
    
            SqlCommand command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@fname", "Test");
            command.Parameters.AddWithValue("@rno", "rno");
    
            command.ExecuteNonQuery();
            command.Dispose();
            cnn.Close();
