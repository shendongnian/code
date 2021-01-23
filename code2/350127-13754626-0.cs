    /// <summary>
    /// Provides a lazily initialised and HttpRuntime.Cache cached value.
    /// </summary>
    public class CachedLazy<T>
    {
        private readonly Func<T> creator;
        /// <summary>
        /// Key value used to store the created value in HttpRuntime.Cache
        /// </summary>
        public string Key { get; private set; }
        /// <summary>
        /// Optional time span for expiration of the created value in HttpRuntime.Cache
        /// </summary>
        public TimeSpan? Expiry { get; private set; }
        /// <summary>
        /// Gets the lazily initialized or cached value of the current Cached instance.
        /// </summary>
        public T Value
        {
            get
            {
                var cache = HttpRuntime.Cache;
                var value = cache[Key];
                if (value == null)
                {
                    lock (cache)
                    {
                        // After acquiring lock, re-check that the value hasn't been created by another thread
                        value = cache[Key];
                        if (value == null)
                        {
                            value = creator();
                            if (Expiry.HasValue)
                                cache.Insert(Key, value, null, Cache.NoAbsoluteExpiration, Expiry.Value);
                            else
                                cache.Insert(Key, value);
                        }
                    }
                }
                return (T)value;
            }
        }
        /// <summary>
        /// Initializes a new instance of the CachedLazy class. If lazy initialization occurs, the given
        /// function is used to get the value, which is then cached in the HttpRuntime.Cache for the 
        /// given time span.
        /// </summary>
        public CachedLazy(string key, Func<T> creator, TimeSpan? expiry = null)
        {
            this.Key = key;
            this.creator = creator;
            this.Expiry = expiry;
        }
    }
