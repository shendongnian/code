    private readonly object gate = new object();
    public string CachedAttr
    {
        get { lock (gate) { return cachedAttribute.Value; } }
    }
    void InvalidateCache()
    {
        lock (gate) { cachedAttribute = new Lazy<string>(initCache, true); }
    }
