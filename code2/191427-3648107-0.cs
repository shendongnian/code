    static int CountUpTo<T>(this IEnumerable<T> source, int maxCount)
    {
        if (maxCount == 0)
            return 0;
        var genericCollection = source as ICollection<T>; 
        if (genericCollection != null) 
            return Math.Min(maxCount, genericCollection.Count);
 
        var collection = source as ICollection; 
        if (collection != null)
            return Math.Min(maxCount, collection.Count);
 
        int count = 0;
        foreach (T item in source)
            if (++count >= maxCount)
                break;
        return count;
    }
