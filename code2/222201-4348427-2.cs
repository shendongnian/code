    private readonly object gate = new object();
    public string CachedAttr
    {
        get
        {
            Lazy<string> lazy;
            lock (gate)                         // 1. Lock
            {
                lazy = this.cachedAttribute;    // 2. Get current Lazy<string>
            }                                   // 3. Unlock
            return lazy.Value                   // 4. Get value of Lazy<string>
                                                //    outside lock
        }
    }
    void InvalidateCache()
    {
        lock (gate)                             // 1. Lock
        {                                       // 2. Assign new Lazy<string>
            cachedAttribute = new Lazy<string>(initCache, true);
        }                                       // 3. Unlock
    }
