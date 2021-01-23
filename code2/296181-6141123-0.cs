    public void Dispose()
    {
      ClientEntityCache.EntityCacheCleared -= ClientEntityCache_CacheCleared;
      // Same thing for 10 other events
    }
