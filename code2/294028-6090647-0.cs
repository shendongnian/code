    using (var connection = new SqlConnection("your connection string"))
    using (var command = connection.CreateCommand())
    {
        command.CommandText = "INSERT into table (Created) VALUES (@Created)";
        command.Parameters.AddWithValue("Created", DateTime.Now);
        connection.Open();
        command.ExecuteNonQuery();
    }
