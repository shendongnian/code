    static IEnumerable<IEnumerable<int>> GroupByProximity(
        this IEnumerable<int> source, int threshold)
    {
        var groups = new List<List<int>>();
        var g = new List<int>();
        foreach (var x in source)
        {
            if ((g.Count != 0) && (x > g[0] + threshold))
            {
                groups.Add(g);
                g = new List<int>();
            }
            g.Add(x);
        }
        groups.Add(g);
        return groups;
    }
