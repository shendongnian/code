public CacheController()
    {
        this._memoryCache = new // whatever memory cache you choose;
    }
You can even better inject it somewhere using dependency injection. The place depends on application type. 
But best of all, try to have only once cache. Each time you create one you lose the previous, so you will either try the singleton pattern, or inject using a single instance configuration and let the DI container handle the rest. 
An example for the singleton implementation: [here][1]
You can access by using:
Cache.Instance.Read(//what)
Here is the cache implementation
using System;
using System.Configuration;
using System.Runtime.Caching;
  
namespace Client.Project.HelperClasses
{
  
    /// <summary>
    /// Thread Safe Singleton Cache Class
    /// </summary>
    public sealed class Cache
    {
        private static volatile Cache instance; //  Locks var until assignment is complete for double safety
        private static MemoryCache memoryCache;
        private static object syncRoot = new Object();
        private static string settingMemoryCacheName;
        private static double settingCacheExpirationTimeInMinutes;
        private Cache() { }
  
        /// <summary>
        /// Singleton Cache Instance
        /// </summary>
        public static Cache Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            InitializeInstance();
  
                        }
                    }
                }
                return instance;
            }
        }
  
        private static void InitializeInstance()
        {
            var appSettings = ConfigurationManager.AppSettings;
            settingMemoryCacheName = appSettings["MemoryCacheName"];
            if (settingMemoryCacheName == null)
                throw new Exception("Please enter a name for the cache in app.config, under 'MemoryCacheName'");
  
            if (! Double.TryParse(appSettings["CacheExpirationTimeInMinutes"], out settingCacheExpirationTimeInMinutes))
                throw new Exception("Please enter how many minutes the cache should be kept in app.config, under 'CacheExpirationTimeInMinutes'");
  
            instance = new Cache();
            memoryCache = new MemoryCache(settingMemoryCacheName);
        }
  
        /// <summary>
        /// Writes Key Value Pair to Cache
        /// </summary>
        /// <param name="Key">Key to associate Value with in Cache</param>
        /// <param name="Value">Value to be stored in Cache associated with Key</param>
        public void Write(string Key, object Value)
        {
            memoryCache.Add(Key, Value, DateTimeOffset.Now.AddMinutes(settingCacheExpirationTimeInMinutes));
        }
  
        /// <summary>
        /// Returns Value stored in Cache
        /// </summary>
        /// <param name="Key"></param>
        /// <returns>Value stored in cache</returns>
        public object Read(string Key)
        {
            return memoryCache.Get(Key);
        }
  
        /// <summary>
        /// Returns Value stored in Cache, null if non existent
        /// </summary>
        /// <param name="Key"></param>
        /// <returns>Value stored in cache</returns>
        public object TryRead(string Key)
        {
            try
            {
                return memoryCache.Get(Key);
            }
            catch (Exception)
            {
                return null;
            }
  
        }
  
    }
  
}
  [1]: https://social.technet.microsoft.com/wiki/contents/articles/32480.a-thread-safe-singleton-cache-helper-class.aspx
