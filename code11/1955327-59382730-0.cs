    serivces.AddSingleton<IMemoryCache, MemoryCache>();
    public static class ItemCacheExtensions
    {
        public static void AddItemCache(this IServiceCollection Services, string ConnectionString, IMemoryCache cache)
        {
            Services.AddSingleton(services => {
               var cache = services.GetService(typeof(IMemoryCache));
               return new ItemCache(cache, ConnectionString));
        }
    }
