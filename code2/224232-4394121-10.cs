    public static string GetUrlContent(string url)
    {
        string urlContent;
        if (TryGetContentFromCache(url, out urlContent))    // todo
            return urlContent;    // got the content
        // content not in the cache so attempt to take out a lock
        object myLock = _locks.GetOrAdd(url, new object());
        lock (myLock)
        {
            if (!TryGetContentFromCache(url, out urlContent))    // todo
            {
                urlContent = FetchContentFromTheWeb(url);    // todo
                AddContentToCache(url, urlContent);    // todo
            }
            // lock no longer required so remove it from the pool
            object expiredLock;
            bool removed = _locks.TryRemove(url, out expiredLock);
            return urlContent;
        }
    }
    private static readonly ConcurrentDictionary<string, object> _locks =
                                      new ConcurrentDictionary<string, object>();
