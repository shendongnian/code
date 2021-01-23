    public static IEnumerable<IEnumerable<T>> Slice<T>(this IEnumerable<T> list, int size)
    {
        var slice = new List<T>();
        foreach (T item in list)
        {
            slice.Add(item);
            if (slice.Count >= size)
            {
                yield return slice;
                slice = new List<T>();
            }
        }
        
        if (slice.Count > 0) yield return slice;
    }
