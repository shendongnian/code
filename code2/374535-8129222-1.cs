    public static T FindFirstAfterIndex<T>(this IEnumerable<T> list,
                                           int index, T item)
    {
        return FindFirstAfterIndex(list, index, item, EqualityComparer<T>.Default);
    }
    public static T FindFirstAfterIndex<T>(this IEnumerable<T> list,
                                           int index, T item,
                                           IEqualityComparer<T> comparer)
    {
        return list.Skip(index)
                   .Where(result => comparer.Equals(result, item))
                   .First();
    }
