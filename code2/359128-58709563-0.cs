    public bool AddToCache(string key, object dataItem,
        DateTimeOffset absoluteExpiration, IEnumerable<string> dependencyKeys)
    {
        CacheItemPolicy policy = new CacheItemPolicy();
        policy.AbsoluteExpiration = absoluteExpiration;
        ChangeMonitor monitor = MemoryCache.Default.CreateCacheEntryChangeMonitor(dependencyKeys);
        policy.ChangeMonitors.Add(monitor);
        return MemoryCache.Default.Add(key, dataItem, policy);
    }
