    // demo, no errorhandling
    public static IEnumerable<T> TakeFrom<T>(this IList<T> list, int offset)
    {
        for (int i = offset; i < list.Count; i += 1)
        {
            yield return list[i];
        }
    }
