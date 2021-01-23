    public static int Count<T>(this IEnumerable<T> source)
    {
        IList list = source as IList;
        if (list != null)
        {
            return list.Count;
        }
        IList<T> genericList = source as IList<T>;
        if (genericList != null)
        {
            return genericList.Count;
        }
        // Okay, we'll do things the slow way...
        int result = 0;
        using (var iterator = source.GetEnumerator())
        {
            while (iterator.MoveNext())
            {
                result++;
            }
        }
        return result;
    }
