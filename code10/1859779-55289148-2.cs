    public class SessionManager : ISessionManager
        {
            private readonly IHttpContextAccessor _contextAccessor;
            private readonly IMemoryCache _cache;
            public SessionManager(IHttpContextAccessor contextAccessor
                                , IMemoryCache cache
            ) {
                _contextAccessor = contextAccessor;
                _cache = cache;
             }
            public T get<T>(string key)
            {
               object data;
               _cache.TryGetValue(buildSessionKey(key), out data);
               return data == null ? default(T) : (T)data;
            }
            public void set(string key, object data, TimeSpan maxLifeTime = default(TimeSpan))
            {
                TimeSpan adjustLifeTime = maxLifeTime.TotalMinutes < 5 ? TimeSpan.FromMinutes(20) : maxLifeTime;
                if (adjustLifeTime.TotalMinutes > 90) adjustLifeTime = TimeSpan.FromMinutes(90);
                MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(20))
                .SetAbsoluteExpiration(adjustLifeTime);
                _cache.Set(buildSessionKey(key), data);
            }
            public void remove(string key) {
                _cache.Remove(buildSessionKey(key));
            }
            private string buildSessionKey(string partialKey) {
                string sessionID = _contextAccessor.HttpContext.Session.Id;
                return sessionID + partialKey;
            } 
        }
 
