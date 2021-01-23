    public static DateTime CheckCachedExpiry()
    {
        DateTime MemCacheEXpirayDate = default(DateTime);
        MemCacheEXpirayDate = Convert.ToDateTime(MemoryCache.Default.Get("MemCahceExpiry"));
        return MemCacheEXpirayDate;
    }
