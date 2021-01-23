    public static ConcurrentBag<SearchResult> Search(string title)
    {
        var results = new ConcurrentBag<SearchResult>();
        Parallel.ForEach(Providers, currentProvider =>
        {
            results.Add(currentProvider.SearchTitle((title)));
        });
        return results;
    }
