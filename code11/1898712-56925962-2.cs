    public static ImmutableList<T> Remove<T>(this ImmutableList<T> immutableList, T item, out bool found)
    {
        var oldCount = immutableList.Count;
        var results = immutableList.Remove(item);
        found = oldCount == results.Count;
        return results;
    }
