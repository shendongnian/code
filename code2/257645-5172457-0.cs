    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int size)
    {
        if (size < 1)
        {
            throw new ArgumentOutOfRangeException("size");
        }
    
        var list = new List<T>(size);
    
        foreach (T item in source)
        {
            list.Add(item);
            if (list.Count == size)
            {
                T[] chunk = list.ToArray();
                list.Clear();
                yield return chunk;
            }
        }
    
        if (list.Count > 0)
        {
            yield return list.ToArray();
        }
    }
