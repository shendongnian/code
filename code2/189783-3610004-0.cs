    public static void ForEach(this IEnumerable<T> collection, Action<T> action)
    {
        foreach(T item in collection)
            action(item);
    }
