    public void ManagedObject : IDisposable
    {
        //A handle to some native resource.
        int* handle;
        public ManagedObject()
        {
            //AllocateHandle is a native method called via P/Invoke.
            handle = AllocateHandle();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                //deal with managed resources here
                FreeHandle(handle);
            }
        }
        ~ManagedType()
        {
            Dispose(false);
        }
    }
