    public class CacheManagerAdapter : ICacheService
        {
            private readonly YYYApi _api;
            private ICacheManager<object> _cacheManager;
            private static readonly string _cacheName;
    
            static CacheManagerAdapter()
            {
                _cacheName = ConfigurationManager.AppSettings["cacheName"] ?? "CancelBookingCache";
            }
    
            public CacheManagerAdapter(IOptions<YYYApi> options)
            {
                _api = options.Value;
    
                _cacheManager = CacheFactory.Build("cacheName", settings => settings
                    .WithUpdateMode(CacheUpdateMode.Up)
                    .WithRedisCacheHandle("redisCache")
                    .And.WithRedisConfiguration("redisCache", _api.cacheHost)
                    .WithJsonSerializer()
                    );
            }
    
            public void Clear()
            {
                _cacheManager.ClearRegion(_cacheName);
            }
    
            public bool Contains(string key)
            {
                return _cacheManager.GetCacheItem(key, _cacheName) == null;
            }
    
            public object Get(string key)
            {
                try
                {
                    return _cacheManager.GetCacheItem(key, _cacheName).Value;
                }
                catch (Exception)
                {
                    return null;
                }
    
            }
    
            public T Get<T>(string key, Func<T> getItemCallback) where T : class
            {
                return _cacheManager.Get<T>(key, _cacheName);
            }
    
            public void Invalidate(Regex pattern)
            {
    
                throw new NotImplementedException();
            }
    
            public void Invalidate(string key)
            {
                _cacheManager.Remove(key, _cacheName);
            }
    
            public bool IsSet(string key)
            {
                throw new NotImplementedException();
            }
    
            public void Set(string key, object data, int cacheTime)
            {
                try
                {
                    _cacheManager.AddOrUpdate(key, _cacheName, data, x => data);
                    if (cacheTime > 0)
                    {
                        _cacheManager.Expire(key, _cacheName, ExpirationMode.Absolute, new TimeSpan(0, cacheTime, 0));
                    }
                }
                catch (Exception ex)
                {
    
                }
            }
        }
