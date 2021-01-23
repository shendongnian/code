    public static IEnumerable<T> Between<T, TKey>(this IList<T> source,
                                                  Func<T, TKey> projection,
                                                  TKey minKeyInclusive,
                                                  TKey maxKeyExclusive,
                                                  IComparer<TKey> comparer)
    {
        comparer = comparer ?? Comparer<TKey>.Default;
        // TODO: Find the index of the lower bound via a binary search :)
        // (It's too late for me to jot it down tonight :)
        int index = ...; // Find minimum index
        while (index < source.Count &&
               comparer.Compare(projection(source[index]), maxKeyExclusive) < 0)
        {
            yield return source[index];
            index++;
        }
    }
