    using (var connection = new SqlConnection(connectionString))
    using (var command = connection.CreateCommand())
    {
        command.CommandText = @"
            INSERT INTO STUDENTS VALUES 
            ('S001', @subjects)";
        command.Parameters.AddWithValue("subjects", string.Join(",", StudentSubjects))
        connection.Open();
        command.ExecuteNonQuery();
    }
