    public static bool TryFindFirstDuplicate<T>(this IEnumerable<T> source, out T duplicate)
    {
        var set = new HashSet<T>();
        foreach (var item in source)
        {
            if (!set.Add(item))
            {
                duplicate = item;
                return true;
            }
        }
        duplicate = default(T);
        return false;
    }
