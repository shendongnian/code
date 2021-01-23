    using(var connection = new OleDbConnection(connectionString))
    using(var command = connection.CreateCommand())
    {
        command.CommandText = SQL;
        command.CommandType = CommandType.Text;
        connection.Open();
        var value = command.ExecuteScalar();
        return value == DBNull.Value ? null : value.ToString();
    }
