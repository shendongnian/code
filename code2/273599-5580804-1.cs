    public static string DoSearch(string query)
    {
        var results = (string)HttpContext.Current.Cache[query];
        if (results == null)
        {
            object miniLock = _miniLocks.GetOrAdd(query, k => new object());
            lock (miniLock)
            {
                results = (string)HttpContext.Current.Cache[query];
                if (results == null)
                {
                    results = GetResultsFromSlowDb(query);
                    HttpContext.Current.Cache.Insert(query, results, null,
                        DateTime.Now.AddHours(1), Cache.NoSlidingExpiration);
                }
                _miniLocks.TryRemove(query);
            }
        }
        return results;
    }
    private static readonly ConcurrentDictionary<string, object> _miniLocks =
                                      new ConcurrentDictionary<string, object>();
