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
        // We don't rely on the optimizations in LINQ to Objects here, as
        // they have changed between versions.
        ICollection<T> genericCollection = source as ICollection<T>;
        if (genericCollection != null)
        {
            return genericCollection.Count == count;
        }
        ICollection nonGenericCollection = source as ICollection;
        if (nonGenericCollection != null)
        {
            return nonGenericCollection.Count == count;
        }
        // Okay, we're finally ready to do the actual work...
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
