    private object _syncRoot = new Object();
    private Dictionary<string, object> _syncRoots = new Dictionary<string, object>();
    
    public static T CheckCache<T>(string key, Func<T> fn, DateTime expires)
    {
        object keySyncRoot;
        lock(_syncRoot)
        {
    
            if(!_syncRoots.TryGetValue(key, out keySyncRoot))
            {
                keySyncRoot = new object();
                _syncRoots[key] = keySyncRoot;
            }
        }
        lock(keySyncRoot)
        {
          
            object cache = HttpContext.Current.Cache.Get(key);
            if (cache == null)
            {
                T result = fn();
                HttpContext.Current.Cache.Insert(key, result, null, expires, 
                                                 Cache.NoSlidingExpiration);
                return result;
            }
            else
                return (T)cache;
        }
    }
