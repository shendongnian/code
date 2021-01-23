    public static IEnumerable<T> Overlap<T>(this IEnumerable<T> first,
        IEnumerable<T> second, IEqualityComparer<T> comparer = null)
    {
        // argument checking, optimisations etc removed for brevity
        var dict = new Dictionary<T, int>(comparer);
        foreach (T item in second)
        {
            int hits;
            dict.TryGetValue(item, out hits);
            dict[item] = hits + 1;
        }
        foreach (T item in first)
        {
            int hits;
            dict.TryGetValue(item, out hits);
            if (hits > 0)
            {
                yield return item;
                dict[item] = hits - 1;
            }
        }
    }
