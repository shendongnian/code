    using (var connection = new SqlConnection(yourConnectionString))
    using (var command = connection.CreateCommand())
    {
       command.CommandText = "insert into YourTable(Col1, Col2) values(@val1, @val2)";
       command.Parameters.AddWithValue("@val1", 123);
       command.Parameters.AddWithValue("@val2", DateTime.Now);
    
       connection.Open();
    
       command.ExecuteNonQuery();
    }
