    var cacheKeys = MemoryCache.Default.Where(kvp.Value is MyType).Select(kvp => kvp.Key).ToList();
    foreach (string cacheKey in cacheKeys)
    {
        MemoryCache.Default.Remove(cacheKey);
    }
