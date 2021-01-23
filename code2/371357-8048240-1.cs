    public void clearCache() {
      var oldCache = TheCache;
      TheCache = new MemoryCache("NewCacheName", ...);
      oldCache.Dispose();
      GC.Collect();
    }
