    public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source,
                                              Func<T, bool> predicate)
    {
        foreach (T item in source)
        {
            yield return item;
            if (predicate(item))
            {
                yield break;
            }
        }
    }
