    public static IEnumerable<Http> enumerate()
    {
        foreach (var key in cache.Keys)
        {
            foreach (var http in (List<Http>)cache[key])
            {
                yield http;
            }
        }
    }
