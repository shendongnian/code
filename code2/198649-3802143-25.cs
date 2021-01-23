    public static bool CountEquals<T>(this IEnumerable<T> source, int count)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("count", 
                                                  "count must not be negative");
        }
        using (IEnumerator<T> iterator = source.GetEnumerator())
        {
            return IteratorCountEquals(iterator, count);
        }
    }
    private static bool IteratorCountEquals<T>(IEnumerator<T> iterator, int count)
    {
        return count == 0 ? !iterator.MoveNext()
            : iterator.MoveNext() && IteratorCountEquals(iterator, count - 1);
    }
