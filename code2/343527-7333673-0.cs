    public class CacheUtil
    {
        private static readonly object locker=new object();
        public static T GetCachedItem<T>(string cacheKey,
                                         Func<T> valueCreateFunc, 
                                         TimeSpan duration)
        {
            var expirationTime = DateTime.UtcNow + duration;
            var cachedItem = HttpRuntime.Cache[cacheKey];
            if (cachedItem == null)
            {
                lock(locker)
                {
                    cachedItem = HttpRuntime.Cache[cacheKey];
                    if (cachedItem == null)
                    {
                        cachedItem = valueCreateFunc();
                        HttpRuntime.Cache.Add(cacheKey,
                                              cachedItem,
                                              null,
                                              expirationTime,
                                              Cache.NoSlidingExpiration,
                                              CacheItemPriority.High,
                                              null);
                    }
                }
                
            }
            return (T) cachedItem;
        }
    }
