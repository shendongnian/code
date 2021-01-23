    public static IEnumerable<IEnumerable<T>> TakeChunks<T>(this IEnumerable<T> source, int size)
    {
        // Typically you'd put argument validation in the method call and then
        // implement it using a private method... I'll leave that to your
        // imagination.
    
        var list = new List<T>(size);
    
        foreach (T item in source)
        {
            list.Add(item);
            if (list.Count == size)
            {
                List<T> chunk = list;
                list = new List<T>(size);
                yield return chunk;
            }
        }
    
        if (list.Count > 0)
        {
            yield return list;
        }
    }
