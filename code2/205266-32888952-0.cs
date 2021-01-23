    public static IEnumerable<TResult> SortBy<TResult, TKey>(this IEnumerable<TResult> sortItems,
                                                             IEnumerable<TKey> sortKeys,
                                                             Func<TResult, TKey> matchFunc)
    {
        return sortKeys.Join(sortItems,
                             k => k,
                             matchFunc,
                             (k, i) => i);
    }
