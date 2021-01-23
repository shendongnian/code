    protected void TableAdapter<T>(Action<T, SqlCeConnection> action) where T : IDisposable, new()
    {
        using (var connection = new SqlCeConnection(ConnectionString))
        using (var tableAdapter = new T())
        {
            action(tableAdapter, connection);
        }
    }
