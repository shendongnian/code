    public Func<string, CachedItem<T>> GetFromCache { get; set; }
    public ClassToTest(IMemoryCache cache)
    {          
        Cache = cache;
        GetFromCache = key => Cache.Get<CachedItem<T>>(key);
    }
