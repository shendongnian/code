    /// <summary>Splits a collection into chunks of equal size. The last chunk may be smaller than chunkSize, but all chunks, if any, will contain at least one element.</summary>
    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunkSize)
    {
        if (chunkSize <= 0)
            throw new ArgumentException("chunkSize must be greater than zero.", "chunkSize");
        return chunkIterator(source, chunkSize);
    }
    private static IEnumerable<IEnumerable<T>> chunkIterator<T>(IEnumerable<T> source, int chunkSize)
    {
        var list = new List<T>();
        foreach (var elem in source)
        {
            list.Add(elem);
            if (list.Count == chunkSize)
            {
                yield return list;
                list = new List<T>();
            }
        }
        if (list.Count > 0)
            yield return list;
    }
