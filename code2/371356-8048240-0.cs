    public void invalidateCache() {
      var oldCache = TheCache;
      TheCache = new MemoryCache("NewCacheName", ...);
      oldCache.Dispose();
      GC.Collect();
    }
