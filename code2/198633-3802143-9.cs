    public static bool CountEquals<T>(this IEnumerable<T> source, int count)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("count must not be negative");
        }
        using (IEnumerator<T> iterator = source.GetEnumerator())
        {
            for (int i = 0; i < count; i++)
            {
                if (!iterator.MoveNext())
                {
                    return false;
                }
            }
            // Check we've got no more
            return !iterator.MoveNext();
        }
    }
