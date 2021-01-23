    public void Dispose()
    {
        foreach (var r in _sources)
        {
            var source = (Action<string>) r.Target;
            if (source != null) 
            {
                source -= Broadcast;
                source = null;
            }
        }
    
        _sources.Clear();
    }
