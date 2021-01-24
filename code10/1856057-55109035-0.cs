    public static IEnumerable<object> DFS(object t)
    {
        var type = t.GetType();
        if (type.FullName?.StartsWith("System.Tuple") != true) // or check inheritanse from ITuple
            yield return t;
        var items = type.GetProperties()
            .Where(p => p.Name.StartsWith("Item"))
            .Select(p => p.GetValue(t))
            .ToArray();
        foreach (var item in items)
        {
            foreach (var innerItem in DFS(item))
            {
                yield return innerItem;
            }
        }
    }
    
