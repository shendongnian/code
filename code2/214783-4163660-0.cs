    public class Test : IDisposable
    {
        ~Test()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            // TODO: Make sure calling Dispose twice is safe
            if (disposing)
            {
                // call Dispose method on other objects
                GC.SuppressFinalize(this);
            }
            // destroy unmanaged resources here
        }
    }
