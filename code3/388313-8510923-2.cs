    private ActionWrapper localSource;
    public void Subscribe(ActionWrapper source)
    {
        source.Action += Broadcast;
        localSource = source;        
    }
    public void Dispose()
    {
        localSource.Action -= Broadcast;
    }
