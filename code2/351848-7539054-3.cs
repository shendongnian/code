    public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> source)
    {
        var query =
            from item in source
            from others in source.SkipOnce(item).Permutations()
            select new[] { item }.Concat(others);
        return query.DefaultIfEmpty(Enumerable.Empty<T>());
    }
    
    public static IEnumerable<T> SkipOnce<T>(this IEnumerable<T> source, T itemToSkip)
    {
        bool skipped = false;
        var comparer = EqualityComparer<T>.Default;
        foreach (var item in source)
        {
            if (!skipped && comparer.Equals(item, itemToSkip))
                skipped = true;
            else
                yield return item;
        }
    }
