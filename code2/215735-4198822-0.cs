    public void Dispose()
    {
       if (isDisposed) { return; }
    
       ....
    
       GC.SuppressFinalize(this);   
       isDisposed = true;
    }
