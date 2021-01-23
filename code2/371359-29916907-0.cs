    public void Flush()
    {
        List<string> cacheKeys = MemoryCache.Default.Select(kvp => kvp.Key).ToList();
        foreach (string cacheKey in cacheKeys)
        {
            MemoryCache.Default.Remove(cacheKey);
        }
    }
