_cacher.GetFromCache(delegate { return ListResults(); }, "ListResults"); 
    public IEnumerable<T> GetFromCache(MethodForCache item, string key, int minutesToCache = 5)
        {
            var cache = _cacheProvider.GetCachedItem(key);
            if (cache == null)
            {
                cache = item.Invoke();
                _cacheProvider.AddCachedItem(cache, key, minutesToCache);
                //_log.Information(string.Format("{0}: Got from service", key));
            }
            else
            {
                //_log.Information(string.Format("{0}: Got from cache", key));
            }
            
            return cache;
        }
