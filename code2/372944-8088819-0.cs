    protected void TableAdapter<T>(Action<T> action) where T : IDisposable, new()
    {
        using (var connection = new SqlCeConnection(ConnectionString))
        using (dynamic tableAdapter = new T())
        {
            tableAdapter.Connection = connection;
            action((T)tableAdapter);
        }
    }
