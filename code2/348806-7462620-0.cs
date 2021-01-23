    public static class CacheHelper
        {
            /// <summary>
            /// Insert value into the cache using
            /// appropriate name/value pairs
            /// </summary>
            /// <typeparam name="T">Type of cached item</typeparam>
            /// <param name="o">Item to be cached</param>
            /// <param name="key">Name of item</param>
            public static void Add<T>(T o, string key, double Timeout)
            {
                HttpContext.Current.Cache.Insert(
                    key,
                    o,
                    null,
                    DateTime.Now.AddMinutes(Timeout),
                    System.Web.Caching.Cache.NoSlidingExpiration);
            }
    
            /// <summary>
            /// Remove item from cache
            /// </summary>
            /// <param name="key">Name of cached item</param>
            public static void Clear(string key)
            {
                HttpContext.Current.Cache.Remove(key);
            }
    
            /// <summary>
            /// Check for item in cache
            /// </summary>
            /// <param name="key">Name of cached item</param>
            /// <returns></returns>
            public static bool Exists(string key)
            {
                return HttpContext.Current.Cache[key] != null;
            }
    
            /// <summary>
            /// Retrieve cached item
            /// </summary>
            /// <typeparam name="T">Type of cached item</typeparam>
            /// <param name="key">Name of cached item</param>
            /// <param name="value">Cached value. Default(T) if item doesn't exist.</param>
            /// <returns>Cached item as type</returns>
            public static bool Get<T>(string key, out T value)
            {
                try
                {
                    if (!Exists(key))
                    {
                        value = default(T);
                        return false;
                    }
    
                    value = (T)HttpContext.Current.Cache[key];
                }
                catch
                {
                    value = default(T);
                    return false;
                }
    
                return true;
            }
        }
