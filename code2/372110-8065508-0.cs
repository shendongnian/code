    public static IEnumerable<IQueryable<T>> InBatches(
        this IQueryable<T> collection, int size)
    {  
        int totalSize = collection.Count();
    
        for (int start = 0; start < totalSize; start += size)
        {
            yield return collection.Skip(start).Take(size);
        }
    }
