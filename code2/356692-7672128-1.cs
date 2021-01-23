    class MyClass : IDisposable
    {
        protected ReaderWriterLockSlim disposeLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        protected bool isDisposed = false; 
        ~MyClass()
        {
            this.Dispose(false);
        }
        public int ExamplePublicProperty
        {
            get
            {
                disposeLock.EnterReadLock();
                try
                {
                    if (isDisposed)
                    {
                        throw new ObjectDisposedException(GetType().FullName);
                    }
                    // The property
                    return 0; // What you want to return
                }
                finally
                {
                    disposeLock.ExitReadLock();
                }
            }
            set
            {
                disposeLock.EnterReadLock();
                try
                {
                    if (isDisposed)
                    {
                        throw new ObjectDisposedException(GetType().FullName);
                    }
                    // The property
                }
                finally
                {
                    disposeLock.ExitReadLock();
                }
            }
        }
        // The same for private methods
        protected int ExampleProtectedProperty
        {
            // Here we don't need to check for isDisposed
            get;
            set;
        }
        public void ExamplePublicMethod()
        {
            disposeLock.EnterReadLock();
            try
            {
                if (isDisposed)
                {
                    throw new ObjectDisposedException(GetType().FullName);
                }
                // The method
            }
            finally
            {
                disposeLock.ExitReadLock();
            }
        }
        // The same for private methods
        protected void ExampleProtectedMethod()
        {
            // Here we don't need to check for isDisposed
        }
        #region IDisposable Members
        public void Dispose()
        {
            disposeLock.EnterWriteLock();
            try
            {
                if (isDisposed)
                {
                    return;
                }
                Dispose(true);
                GC.SuppressFinalize(this);
                isDisposed = true;
            }
            finally
            {
                disposeLock.ExitWriteLock();
            }
        }
        #endregion
        protected virtual void Dispose(bool disposing)
        {
            // do the freeing
        }
    }
