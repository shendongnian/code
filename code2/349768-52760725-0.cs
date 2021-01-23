     class ConnectionConfiguration:IDisposable
    {
        private static volatile IConnection _rbMqconnection;
        private static readonly object ConnectionLock = new object();
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            if (_rbMqconnection == null)
            {
                return;
            }
            lock (ConnectionLock)
            {
                if (_rbMqconnection == null)
                {
                    return;
                }
                _rbMqconnection?.Dispose();//double check
                _rbMqconnection = null;
            }
        }
    }
