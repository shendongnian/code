    class HelperClass : IDisposable
    {
        private bool _disposed;
        private OleDbConnection _connection;
        public HelperClass()
        {
            _connection = << open the conection >>;
        }
        public OledbDataReader GetOpenedReader()
        {
            return << open your reader here with the connection >>;
        }
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                _connection.Dispose();
            }
        }
    }
