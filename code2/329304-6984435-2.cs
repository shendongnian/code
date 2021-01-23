    public static T CheckCache<T>(string key, Func<T> fn, DateTime expires)
    {
        object cached = HttpContext.Current.Cache[key];
        if (cached != null)
            return (T)cached;
            
        int stripeIndex = (key.GetHashCode() & 0x7FFFFFFF) % _stripes.Length;
        lock (_stripes[stripeIndex])
        {
            T result = fn();
            HttpContext.Current.Cache.Insert(key, result, null, expires,
                                             Cache.NoSlidingExpiration);
            return result;
        }
    }
    // share a set of 32 locks
    private static readonly object[] _stripes = Enumerable.Range(0, 32)
                                                          .Select(x => new object())
                                                          .ToArray();
