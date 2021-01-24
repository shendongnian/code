    public static IEnumerable<IEnumerable<T>> GroupBy<T>(this IEnumerable<T> source, Func<T, T, bool> func)
    {
        var items = new List<T>();
        foreach (var item in source)
        {
            if (items.Count != 0)
                if (!func(items[0], item))
                {
                    yield return items;
                    items = new List<T>();
                }
            items.Add(item);
        }
        if (items.Count != 0)
            yield return items;
    }
