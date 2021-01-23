    public static void AddFrom<T>(this ICollection<T> destList, IEnumerable<T> sourceList)
    {
        foreach (T obj in sourceList)
        {
            destList.Add(obj);
        }
    }
