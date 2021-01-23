        Source: System.Runtime.Caching
        Exception type: System.InvalidOperationException
        Message: The method has already been invoked, and can only be invoked once.
        Stacktrace:    at System.Runtime.Caching.ChangeMonitor.NotifyOnChanged(OnChangedCallback onChangedCallback)
                       at System.Runtime.Caching.MemoryCacheEntry.CallNotifyOnChanged()
                       at System.Runtime.Caching.MemoryCacheStore.AddToCache(MemoryCacheEntry entry)
                       at System.Runtime.Caching.MemoryCacheStore.Set(MemoryCacheKey key, MemoryCacheEntry entry)
                       at System.Runtime.Caching.MemoryCache.Set(String key, Object value, CacheItemPolicy policy, String regionName)
