    ~MyObject()
    {
        Dispose(false);  // False because it's being called in a finalizer
    }
    public void Dispose()
    {
        Dispose(true);  // True because it was called from user code
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            // here it's safe to access other CLR objects
        }
        // Here you dispose of any unmanaged objects
    }
