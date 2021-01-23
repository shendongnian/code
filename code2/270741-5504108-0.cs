    private StackTrace m_stackAtConstruction;
    public Constructor()
    {
         m_stackAtConstruction = new StackTrace();
    }
    public void Dispose() 
    {
        Dispose(true);
        // Use SupressFinalize in case a subclass
        // of this type implements a finalizer.
        GC.SuppressFinalize(this);      
    }
    protected virtual void Dispose(bool disposing)
    {
        // If you need thread safety, use a lock around these 
        // operations, as well as in your methods that use the resource.
        if (!_disposed)
        {
            if (disposing) {
                if (_resource != null)
                    _resource.Dispose();
                    Console.WriteLine("Statck trace at construction was " + m_stackAtConstruction.ToString());
            }
            // Indicate that the instance has been disposed.
            _resource = null;
            _disposed = true;   
        }
    } 
