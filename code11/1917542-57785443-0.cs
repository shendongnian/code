    static MemoryCache memCacheObject = MemoryCache.Default;
        
    public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
    {
        var cacheObj = memCacheObject["cachedCount"];
        var cachedCount = (cacheObj == null) ? 0 : (int)cacheObj;   
        memCacheObject.Set("cachedCount", ++cachedCount, DateTimeOffset.Now.AddMinutes(5));
    
        log.Info($"Webhook triggered memory count {cachedCount}");
        return ...
    }
