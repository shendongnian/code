    class MockDisposable : IDisposable
    {
        bool _disposed = false;
    
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed) // only dispose once!
            {
                if (disposing)
                {
                    // Not in destructor, OK to reference other objects
                }
                // perform cleanup for this object
            }
            _disposed = true;
        }
    
        public void Dispose()
        {
            Dispose(true);
    
            // tell the GC not to finalize
            GC.SuppressFinalize(this);
        }
    
        ~MockDisposable()
        {
            Dispose(false);
        }
    }
