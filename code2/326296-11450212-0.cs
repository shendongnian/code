    internal class Cache
    {
        private Object Statlock = new object();
        private int ItemCount;
        private long size;
        private MemoryCache MemCache;
        private CacheItemPolicy CIPOL = new CacheItemPolicy();
        public Cache(double CacheSize)
        {
            NameValueCollection CacheSettings = new NameValueCollection(3);
            CacheSettings.Add("cacheMemoryLimitMegabytes", Convert.ToString(CacheSize));
            CacheSettings.Add("pollingInterval", Convert.ToString("00:00:01"));
            MemCache = new MemoryCache("TestCache", CacheSettings);
        }
        public void AddItem(string Name, string Value)
        {
            CacheItem CI = new CacheItem(Name, Value);
            MemCache.Add(CI, CIPOL);
            Console.WriteLine(MemCache.GetCount());
        }
    }
