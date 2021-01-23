        [OperationContract]
        public List<Guid> SomeWebMethod()
        {
            if (_cacheManager.Contains("rgal")) // data in cache?
                    result = (List<Guid>)_cacheManager.GetData("rgal");
                if (result == null)
                {
                    
                    result = FETCH FROM DATABASE HERE;
                    // cache for 120 minutes
                    _cacheManager.Add("rgal", result, CacheItemPriority.Normal, null, new AbsoluteTime(TimeSpan.FromMinutes(120)));
                }
                        return result;
        }
  
