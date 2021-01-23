    [Pure]
    public static IList<T> RemoveItem<T>(this IEnumerable<T> thisList, T item)
    {
        var list = thisList.ToList();
        list.Remove(item);
        return list;
    }
