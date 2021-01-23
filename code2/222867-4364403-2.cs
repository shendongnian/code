    class A : IDisposable
    {
        private bool _disposed;
        ~A()
        {
            this.Dispose(false);
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // dispose managed resources
                }
                // dispose unmanaged resources
                _disposed = true;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var someInstance = new A())
            {
                // do some things with the class.
                // once the using block completes, Dispose
                // someInstance.Dispose() will automatically
                // be called
            }
        }
    }
