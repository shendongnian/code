    public Func<CachedItem<T>, string> GetFromCache { get; set; }
    public ClassToTest(IMemoryCache cache)
    {          
        Cache = cache;
        GetFromCache = key => Cache.Get<CachedItem<T>>(key);
    }
