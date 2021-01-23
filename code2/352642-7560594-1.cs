    List<Article> g = new List<Article>(GetFeatureArticles());
    
    foreach (Article a in g)
    {
    if (result.Contains (a))
        result.Remove (a);
    }
    
    g.AddRange (result);
    
    return g;
