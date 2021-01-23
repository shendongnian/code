    private IDataReader CreateReader(string queryString,
        string connectionString)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(queryString, connection);
        connection.Open();
        return command.ExecuteReader(CommandBehavior.CloseConnection);
        // Don't close connection
    }
