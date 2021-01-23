    class MyClass : IDisposable
    {
    
        ~MyClass()
        {
            Dispose(false);
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                }
                // Dispose unmanaged resources
                disposed = true;
            }
        }
    
    }
