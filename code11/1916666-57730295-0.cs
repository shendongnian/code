    public static bool SequenceHasExactlyOneElement<T>(this IEnumerable<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        using(var enumerator = source.GetEnumerator())
            return enumerator.MoveNext() && !enumerator.MoveNext();
    }
