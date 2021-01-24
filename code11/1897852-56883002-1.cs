    protected IEnumerable<T> ExecuteQuery<T>(string query, object parameters = null, CommandType? commandType = null)
    {
        using (var conn = Connection)
        {
            return conn.Query<T>(query, parameters, commandType: commandType, commandTimeout: 0);
        }
    }
