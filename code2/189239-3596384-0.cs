    public static void IterateWithSpecialFirst<T>(this IEnumerable<T> source,
        Action<T> firstAction,
        Action<T> subsequentActions)
    {
        using (IEnumerator<T> iterator = source.GetEnumerator())
        {
            if (iterator.MoveNext())
            {
                firstAction(iterator.Current);
            }
            while (iterator.MoveNext())
            {
                subsequentActions(iterator.Current);
            }
        }
    }
