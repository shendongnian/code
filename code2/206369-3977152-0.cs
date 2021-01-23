    class Cache
    {
        static readonly Dictionary<string, ICollection<MatchedLocation>> _cache = new Dictionary<string, ICollection<MatchedLocation>>(100);
        static readonly Dictionary<string,DateTime> _cacheTimes = new Dictionary<string, DateTime>(100);
        static readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        public ICollection<MatchedLocation> FindLocations(string queryText)
        {
            _lock.EnterUpgradeableReadLock();
            try
            {
                ICollection<MatchedLocation> result;
                if (_cache.TryGetValue(queryText, out result))
                {
                    return result;
                }
                else
                {
                    _lock.EnterWriteLock();
                    try
                    {
                        // expire cache items
                        if( _cache.Count > 100)
                        {
                            // could be more efficient http://code.google.com/p/morelinq/ - MinBy
                            string key = _cacheTimes.OrderBy(item => item.Value).First().Key;
                            _cacheTimes.Remove(key);
                            _cache.Remove(key);
                        }
                        // add new item
                        result = dbPersistence.GetLocations(queryText);
                        _cache[queryText] = result;
                        _cacheTimes[queryText] = DateTime.UtcNow;                        
                    }
                    finally
                    {
                        _lock.ExitWriteLock();
                    }
                    return result;
                }
            }
            finally
            {
                _lock.ExitUpgradeableReadLock();
            }
        }
    }
