    private StackTrace m_stackAtConstruction;
    private bool m_disposed;
    public Constructor()
    {
         m_stackAtConstruction = new StackTrace();
         m_disposed=false;
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
        if (!m_disposed)
        {
            if (disposing) {
                if (_resource != null)
                    _resource.Dispose();
                    
            }
            else
            {
                 Console.WriteLine("Object not disposed correctly - Stack trace at construction was " + m_stackAtConstruction.ToString());
            }
            // Indicate that the instance has been disposed.
            _resource = null;
            _disposed = true;   
        }    
    } 
