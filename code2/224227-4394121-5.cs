    public static string GetUrlContent(string url)
    {
        object value1 = _cache.GetOrAdd(url, new object());
        if (value1 == null)    // null check only required if content
            return null;       // could legitimately be a null string
        var urlContent = value1 as string;
        if (urlContent != null)
            return urlContent;    // got the content
        // value1 isn't a string which means that it's an object to lock against
        lock (value1)
        {
            object value2 = _cache[url];
            // at this point value2 will *either* be the url content
            // *or* the object that we already hold a lock against
            if (value2 != value1)
                return (string)value2;    // got the content
            urlContent = FetchContentFromTheWeb(url);    // todo
            _cache[url] = urlContent;
            return urlContent;
        }
    }
    private static readonly ConcurrentDictionary<string, object> _cache =
                                      new ConcurrentDictionary<string, object>();
