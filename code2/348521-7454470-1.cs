    private static CacheItemPolicy GetCachePolicy(CacheType type, int expiry, 
                                                 CacheEntryUpdateCallback method)
    {
         ...
         policy.UpdateCallback = method;
         ...
         return policy;
    }
