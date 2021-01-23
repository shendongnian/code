    public static IList<T> AsSingletonList<T>(this IEnumerable<T> source)
    {
        foreach (var item in source)
        {
            return new System.Collections.ObjectModel.ReadOnlyCollection<T>(new T[] { item });
        }
        return new System.Collections.ObjectModel.ReadOnlyCollection<T>(new T[] { default(T) });
    }
