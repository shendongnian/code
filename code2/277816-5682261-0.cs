    public sealed class YourClass : IDisposable
    {
        private MySqlConnection _Connection;
        private bool _IsDisposed;
        public YourClass()
        {
            _Connection = new MySqlConnection();
        }
        public void Dispose()
        {
            if (!_IsDisposed)
            {
                _Connection.Dispose(); // or Close
                _IsDisposed = false;
            }
        }
    }
