    public static void AddDistinct<T>(this ICollection<T> source, params IEnumerable<T> items)
    {
        var set = new HashSet<T>(source);
        foreach(var item in items)
        {
            if(set.Add(item))
                source.Add(item);
        }
    }
