_cacher.GetFromCache(delegate { return ListResults(); }, "ListResults"); 
    public IEnumerable<T> GetFromCache(MethodForCache item, string key, int minutesToCache = 5)
        {
            var cache = _cacheProvider.GetCachedItem(key);
            //you could even have a UseCache bool here for central control
            if (cache == null)
            {
                //you could put timings, logging etc. here instead of all over your code
                cache = item.Invoke();
                _cacheProvider.AddCachedItem(cache, key, minutesToCache);
            }            
            
            return cache;
        }
