        public class CacheUtil
        {
            private static DataCacheFactory _factory = null;
            private static DataCache _cache = null;
    
            // This is the single instance of this class
            private static readonly CacheUtil instance = new CacheUtil();
            
            private CacheUtil()
            {
                _cache = GetCache();
            }        
            
            /// <summary>
            /// Provides the single reference point to access this class
            /// </summary>
            public static CacheUtil Instance
            {
                get { return instance; }
            }
    
            private static DataCache GetCache()
            {
                if (_cache != null)
                    return _cache;
    
                //-------------------------
                // Configure Cache Client 
                //-------------------------
    
                //Define Array for 1 Cache Host
                List<DataCacheServerEndpoint> servers =
                    new List<DataCacheServerEndpoint>(1);
    
                //Specify Cache Host Details 
                //  Parameter 1 = host name
                //  Parameter 2 = cache port number
                servers.Add(new DataCacheServerEndpoint("localhost", 22233));
    
                //Create cache configuration
                DataCacheFactoryConfiguration configuration = new DataCacheFactoryConfiguration { 
    Servers = servers, 
    
    LocalCacheProperties = new DataCacheLocalCacheProperties() };
    
                //Disable tracing to avoid informational/verbose messages on the web page
                DataCacheClientLogManager.ChangeLogLevel(System.Diagnostics.TraceLevel.Off);
    
                //Pass configuration settings to cacheFactory constructor
                _factory = new DataCacheFactory(configuration);
    
                //Get reference to named cache called "default"
                _cache = _factory.GetCache("default");
    
                return _cache;
            }
            /// <summary>
            /// Gets the cache
            /// </summary>
            public DataCache Cache { get; private set; }
        }
