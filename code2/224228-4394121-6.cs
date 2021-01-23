    public static string GetUrlContent(string url)
    {
        string urlContent;
        if (TryGetContentFromCache(url, out urlContent))    // todo
            return urlContent;
        object myLock = _locks.GetOrAdd(url, new object());
        lock (myLock)
        {
            if (TryGetContentFromCache(url, out urlContent))    // todo
                return urlContent;
            urlContent = FetchContentFromTheWeb(url);    // todo
            AddContentToCache(url, urlContent);    // todo
            object expiredLock;
            bool removed = _locks.TryRemove(url, out expiredLock);
            return urlContent;
        }
    }
    private static readonly ConcurrentDictionary<string, object> _locks =
                                      new ConcurrentDictionary<string, object>();
