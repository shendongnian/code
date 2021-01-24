    public class DataFacade {
        private readonly IMemoryCache _cache;
        public DataFacade(IMemoryCache memoryCache) {
            _cache = memoryCache;
        }
        //...
