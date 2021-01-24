    private void ExecuteSql(SqlCommand command, Action<SqlDataReader> action)
    {
        using (var connection = new SqlConnection(ConnectionText, Credentials))
        {
            command.Connection = connection;
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                action(reader);
            }
        }
    }
