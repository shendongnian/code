`
    private static CacheItemPolicy GetCachePolicy(CacheType type, int expiry, Func<?,?> method)
    {
        var policy = new CacheItemPolicy();
        switch (type)
        {
            case (CacheType.Absolute):
                    Action<CacheEntryUpdateArguments> updateCallBackHandler = null;
                    updateCallBackHandler = delegate(CacheEntryUpdateArguments arguments)
                    {                         
                        var newData = FetchYourDataWithCustomParameters();
                        arguments.UpdatedCacheItem = new CacheItem(arguments.Key, newData);
                        arguments.UpdatedCacheItemPolicy = new CacheItemPolicy()
                        {
                            AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(expiry),
                            UpdateCallback = new CacheEntryUpdateCallback(updateCallBackHandler)
                        };
                    };
                    policy.UpdateCallback = new CacheEntryUpdateCallback(updateCallBackHandler);
                break;
            case (CacheType.Sliding):
                policy.SlidingExpiration = new TimeSpan(0, 0, 0, expiry);
                break;
        }
        return policy;
    }
'
