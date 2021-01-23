    /// <summary>
    /// Returns the index of the first element in this <paramref name="source"/>
    /// satisfying the specified <paramref name="condition"/>. If no such elements
    /// are found, returns -1.
    /// </summary>
    public static int IndexOf<T>(this IEnumerable<T> source, Func<T, bool> condition)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (condition == null)
            throw new ArgumentNullException("condition");
        int index = 0;
        foreach (var v in source)
        {
            if (condition(v))
                return index;
            index++;
        }
        return -1;
    }
