    public static IEnumerable<T> Delay(this IEnumerable<T> source, int interval)
    {
        foreach (T item in source)
        {
            Thread.Sleep(interval);
            yield return item;
        }
    }
