    public class BaseClass : IDisposable
    {
        private bool _disposed = false;
        protected DbContext Context { get; }
    
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this._disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Disposes managed resources here
                    if (this.Context != null)
                    {
                        this.Context.Dispose();
                    }
                }
    
                // Disposes unmanaged resources here
                // NOTHING HERE
    
                // Note disposing has been done.
                this._disposed = true;
            }
        }
    }
