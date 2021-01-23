    public static IEnumerable<T> SkipFirstMatching<T>
          (this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null)
            throw new ArgumentNullException("source");
    
        if (predicate == null)
            throw new ArgumentNullException("predicate");
    
        bool itemToSkipSeen = false;
    
        foreach (T item in source)
        {
            if (!itemToSkipSeen && predicate(item))
                itemToSkipSeen = true;
    
            else yield return item;
        }
    }
