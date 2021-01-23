    private static IEnumerable<TResult> RankBy<TSource, TKey, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        IComparer<TKey> comparer,
        bool descending,
        Func<TSource, int, TResult> resultSelector)
    {
        var comp0 = comparer ?? Comparer<TKey>.Default;
        var comp = descending ? Comparer<TKey>.Create((x, y) => -comp0.Compare(x, y)) : comp0;
        var keys = source.Select(x => keySelector(x)).ToArray();
        var indexes = Enumerable.Range(0, keys.Length).ToArray();
        Array.Sort<TKey, int>(keys, indexes, comp);
        var groups = new int[keys.Length];
        int group = 0;
        int index = 0;
        for (int j = 1; j < keys.Length; ++j)
        {
            ++index;
            if (comp.Compare(keys[j], keys[j - 1]) != 0)
            {
                group += index;
                index = 0;
            }
            groups[indexes[j]] = group;
        }
        index = 0;
        foreach (var item in source)
        {
            yield return resultSelector(item, groups[index++] + 1);
        }
    }
    private static IEnumerable<TResult> DenseRankBy<TSource, TKey, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        IComparer<TKey> comparer,
        bool descending,
        Func<TSource, int, TResult> resultSelector)
    {
        var comp0 = comparer ?? Comparer<TKey>.Default;
        var comp = descending ? Comparer<TKey>.Create((x, y) => -comp0.Compare(x, y)) : comp0;
        var keys = source.Select(x => keySelector(x)).ToArray();
        var indexes = Enumerable.Range(0, keys.Length).ToArray();
        Array.Sort<TKey, int>(keys, indexes, comp);
        var groups = new int[keys.Length];
        int group = 0;
        for (int j = 1; j < keys.Length; ++j)
        {
            if (comp.Compare(keys[j], keys[j - 1]) != 0)
                ++group;
            groups[indexes[j]] = group;
        }
        int index = 0;
        foreach (var item in source)
        {
            yield return resultSelector(item, groups[index++] + 1);
        }
    }
