    private static CacheItemPolicy GetCachePolicy(CacheType type, int expiry, 
                                        Action<CacheEntryUpdateArguments> method)
    {
         ...
         policy.UpdateCallback = (a) => method(a);
         ...
         return policy;
    }
