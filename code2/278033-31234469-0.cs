    IDataReader ReadAll()
    {
        var connection = new SqlConnection(connectionString);
        try
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM mytable";
            var result = command.ExecuteReader(CommandBehavior.CloseConnection);
            connection = null; // Don't dispose the connection.
            return result;
        }
        finally
        {
            if (connection != null)
                connection.Dispose();
        }
    }
