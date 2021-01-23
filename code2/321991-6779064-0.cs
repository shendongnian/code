    // C# -- new connection for each users
    IEnumerable<SqlConnection> mapUserToConnection(string user)
    {
        while (true)
        using (var conn = new SqlConnection())
        {
            yield return conn;
        }
    }
