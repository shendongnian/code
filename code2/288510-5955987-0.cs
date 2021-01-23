    public static IEnumerable<T> Take<T>(IEnumerable<T> source, int size)
    {
        int count = 0;
        foreach (T item in source)
        {
            yield return item;
            count++;
            if (count == size)
            {
                yield break;
            }
        }
    }
