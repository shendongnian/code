    static IEnumerable<IEnumerable<int>> GroupByProximity(
        this IEnumerable<int> source, int threshold)
    {
        var g = new List<int>();
        foreach (var x in source)
        {
            if ((g.Count != 0) && (x > g[0] + threshold))
            {
                yield return g;
                g = new List<int>();
            }
            g.Add(x);
        }
        yield return g;
    }
