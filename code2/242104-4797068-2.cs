    public static void AddFrom<T>(this ISet<T> destList, IEnumerable<T> sourceList)
    {
        foreach (T obj in sourceList)
        {
            destList.Add(obj);
        }
    }
