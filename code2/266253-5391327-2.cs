    public static bool IsUnique<T>(this IEnumerable<T> list)
    {
        var hs = new HashSet<T>();
        return list.All(hs.Add);  
    }
