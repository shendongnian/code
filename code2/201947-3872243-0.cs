    public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> source, int size)
    {
        int i = 0;
        List<T> list = new List<T>(size);
        foreach (T item in source)
        {
            list.Add(item);
            if (++i == size)
            {
                yield return list;
                list = new List<T>(size);
                i = 0;
            }
        }
        if (list.Count > 0)
            yield return list;
    }
