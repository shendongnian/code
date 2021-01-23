    private readonly object gate = new object();
    public string CachedAttr
    {
        get
        {
            Lazy<string> lazy;
            lock (gate) { lazy = this.cachedAttribute; }
            return lazy.Value
        }
    }
    void InvalidateCache()
    {
        lock (gate) { cachedAttribute = new Lazy<string>(initCache, true); }
    }
