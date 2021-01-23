    /// <summary>
    /// Replaces items in a list that match the specified predicate,
    /// based on the specified selector. 
    /// </summary>
    public static void ReplaceWhere<T>(this IList<T> list,
                                       Func<T, bool> predicate,
                                       Func<T, T> selector)
    {
        // null-checks here.
        for (int i = 0; i < list.Count; i++)
        {
            T item = list[i];
            if (predicate(item))
                list[i] = selector(item);
        }
    }
