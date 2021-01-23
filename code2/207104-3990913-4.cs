    public virtual void Close()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }
 
