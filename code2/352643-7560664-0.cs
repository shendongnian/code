    foreach (Article a featuredArticles)
    {
        if (resultsDictionary.ContainsKey(a.Key))
        {
            resultsDictionary.Remove(a.Key);
        }
    }
