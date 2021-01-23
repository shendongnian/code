    private Action<string> localSource;
    public void Subscribe(ref Action<string> source)
    {
        source += Broadcast;
        localSource = source;
        //Store the reference somehow?
    }
    public void Dispose()
    {
        localSource -= Broadcast;
    }
