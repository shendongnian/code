    public bool IsCancellationRequested 
    {
        get
        {
            return source != null && source.IsCancellationRequested;
        }
    }
