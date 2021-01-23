    public static IList<T> Add(this IList<T> list, T item)
    {
        list.Add(item);
        return list;
    }
