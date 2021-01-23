    private List<Action<string>> localSources;
    public void Subscribe(ref Action<string> source)
    {
        source += Broadcast;
        localSources.Add(source);
    }
    public void Dispose()
    {
        foreach(Action<string> source in localSources)
            localSource -= Broadcast;
    }
