    class MyClass : IDisposable
    {
        ~MyClass() 
        {
            Dispose(false);
        }
        public void Dispose()
        {
            GC.SupressFinalize();
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                // clear unmanaged resources here (can only be called once)
                ...
            }
            
            // dispose called explicitly by the user, clean up managed resources here
            ...
        }
    }
