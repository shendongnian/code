    public static string GetUrlContent(string url)
    {
        object value1 = _cache.GetOrAdd(url, new object());
        if (value1 == null)    // null check only required if content
            return null;       // could legitimately be a null string
        var urlContent = value1 as string;
        if (urlContent == null)
        {
            lock (value1)
            {
                object value2 = _cache[url];
                if (value2 == value1)
                {
                    urlContent = // fetch url content
                    _cache[url] = urlContent;
                }
            }
        }
        return urlContent;
    }
    private static readonly ConcurrentDictionary<string, object> _cache =
                                      new ConcurrentDictionary<string, object>();
