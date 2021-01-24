    public class MyCache
    {
      private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
      private string nullValue = Guid.NewGuid().ToString();
    
      public void Set(string cacheKey, string toSet)
        => _cache.Set<string>(cacheKey, toSet == null ? nullValue : toSet);
    
      public string Get(string cacheKey)
      {
        var isInCache = _cache.TryGetValue(cacheKey, out string cachedVal);
        if (!isInCache) return null;
    
        return cachedVal == nullValue ? null : cachedVal;
      }
    }
