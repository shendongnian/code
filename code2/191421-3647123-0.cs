    public static IEnumerable<T> Duplicates<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, IEqualityComparer<TKey> comparer)
    {
        source.ThrowIfNull("source");
        keySelector.ThrowIfNull("keySelector");
        comparer = comparer ?? EqualityComparer<TKey>.Default;
        
        return source.GroupBy(keySelector, comparer)
            .Where(g => g.CountAtLeast(2))
            .SelectMany(g => g);
    }
    
    public static IEnumerable<T> Duplicates<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
    {
        return source.Duplicates(keySelector, null);
    }
    
    public static IEnumerable<T> Duplicates<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
    {
        return source.Duplicates(x => x, comparer);
    }
    
    public static IEnumerable<T> Duplicates<T>(this IEnumerable<T> source)
    {
        return source.Duplicates(null);
    }
