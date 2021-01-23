    public static List<SearchResult> Search(string title)
    {
        return Providers.AsParallel()
                        .SelectMany(p => p.SearchTitle(title))
                        .ToList();
    }
