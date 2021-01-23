    public static void SetObjectToCache<T>(string cacheItemName, T obj, long expireTime)
            {
                ObjectCache cache = MemoryCache.Default;
    
                var cachedObject = (T)cache[cacheItemName];
    
                if (cachedObject != null)
                {
                    // remove it
                    cache.Remove(cacheItemName);
                }
    
                CacheItemPolicy policy = new CacheItemPolicy()
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMilliseconds(expireTime),
                    RemovedCallback = new CacheEntryRemovedCallback(CacheRemovedCallback)
                };
    
                cachedObject = obj;
                cache.Set(cacheItemName, cachedObject, policy);
            }
    
    public static void CacheRemovedCallback(CacheEntryRemovedArguments arguments)
                {
                    var configServerIpAddress = Thread.CurrentPrincipal.ConfigurationServerIpAddress();
                    long configId = Thread.CurrentPrincipal.ConfigurationId();
                    int userId = Thread.CurrentPrincipal.UserId();
                    var tagInfoService = new TagInfoService();
                    string returnCode = string.Empty;
        
                    if (arguments.CacheItem.Key.Contains("DatatableTags_"))
                    {
                        // do what's needed
                        Task.Run(() =>
                        {
                        });
                    }
        
                }
