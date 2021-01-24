    public class ABC
    {
      private readonly IMemoryCache _cache;
      private readonly IConfiguration _config;
      private readonly IDistributedCache _distributedCache;
    
      public ABC(IMemoryCache memoryCache, IConfiguration config, IDistributedCache distributedCache)
      {
       _cache = memoryCache;
       _config = config;
       _distributedCache = distributedCache;
      }
      public ABC() : this(new MemoryCache, new Configuration(), new DistributedCache )
      {
      }
    }
