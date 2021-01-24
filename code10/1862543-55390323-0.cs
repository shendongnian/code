    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> range)
    {
        foreach (T t in range)
        {
            collection.Add(t);
        }
    }
