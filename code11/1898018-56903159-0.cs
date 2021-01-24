    public static IEnumerable<IEnumerable<T>> SplitOn<T>(
        this IEnumerable<T> items, 
        Func<T, bool> split)
    {
        var g = new List<T>();
        foreach(var item in items)
        {
            if(split(item) && g.Count > 0)
            {
                yield return g;
                g = new List<T>();
            }
        
            g.Add(item);
        }
        if(g.Count > 0) yield return g;
    }
    
