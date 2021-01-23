    public static bool None<TSource>(this IEnumerable<TSource> source) 
    {
        if (source == null) { throw new ArgumentNullException(nameof(source)); }
    
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
            return !enumerator.MoveNext();
        }
    }
    public static bool None<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        if (source == null) { throw new ArgumentNullException(nameof(source)); }
        if (predicate == null) { throw new ArgumentNullException(nameof(predicate)); }
                
        foreach (TSource item in source)
        {
            if (predicate(item))
            {
                return false;
            }
        }
    
        return true;
    }
