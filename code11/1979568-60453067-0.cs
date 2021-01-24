    public StateService
    {
        private readonly ObjectCache _cache = MemoryCache.Default;
        private const string _queueStatesCacheKey = "_states";
        private static SemaphoreSlim semaphore = new SemaphoreSlim(0, 1);
    
        public IList<States> GetStates()
        {
            var states = _cache.Get(_statesCacheKey);
            if (states== null)
            {
               try
               {
                  semaphore.Wait();
                  // we check again from cache, that could have been populated from other thread
                  states = _cache.Get(_statesCacheKey);
                  if(states != null) return states as IList<States>;
                  states = getStatesFromDatabase();
                  _cache.Set(_statesCacheKey, states, DateTimeOffset.Now.AddSeconds(Settings.AppSettings.QueueStateCacheExpiration));
               }
               finally
               {
                  semaphore.Release();
               }
            }
            return states as List<States>;
        }
    }
