    class MyConnection : IDisposable
    {
        public void OpenConnnection() { ... }
        public void CloseConnection() { ... }
        public void Dispose() { ... CloseConnection(); ... }
    }
