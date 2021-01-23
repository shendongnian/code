    public static IList<T> AsSingletonList<T>(this IEnumerable<T> source)
    {
        IList<T> result = null;
        foreach (var item in source)
        {
            if (result != null)
                throw new ArgumentOutOfRangeException("source", "Source had more than one value.");
            result = new System.Collections.ObjectModel.ReadOnlyCollection<T>(new T[] { item });
        }
        if (result == null)
            throw new ArgumentOutOfRangeException("source", "Source had no values.");
        return result;
    }
