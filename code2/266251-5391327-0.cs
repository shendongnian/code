    public static bool IsUnique<T>(this IEnumerable<T> list)
    {
        varhs = new HashSet<T>();
        return list.All(hs.Add);  
    }
