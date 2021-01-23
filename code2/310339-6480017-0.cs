    using (var connection = new SqlCeConnection(Settings.Default.Database1ConnectionString))
    using (var command = connection.CreateCommand())
    {
        connection.Open();
        command.CommandText = @"
            INSERT Test (Name)
            VALUES (@TestName)
            ";
        command.Parameters.AddWithValue("TestName", "SomeName");
        command.ExecuteNonQuery();
        command.CommandText = "SELECT @@IDENTITY";
        var id = command.ExecuteScalar();
    }
