    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, Func<T, bool> isSeparator)
    {
        List<T> list = new List<T>();
        foreach(T item in source)
        {
            if (isSeparator(item))
            {
                if (list.Count > 0)
                {
                    yield return list;
                    list = new List<T>();
                }
            }
            list.Add(item);
        }
    
        if (list.Count > 0)
        {
            yield return list;
        }
    }
