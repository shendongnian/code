    using (var connection = new MySqlConnection(connectionString))
    using (var command = connection.CreateCommand())
    {
        command.CommandText = @"
            INSERT INTO STUDENTS VALUES 
            ('S001', ?subjects)";
        var param = command.Parameters.Add("?subjects", MySqlDbType.VarChar);
        param.Value = string.Join(",", StudentSubjects);
        connection.Open();
        command.ExecuteNonQuery();
    } 
