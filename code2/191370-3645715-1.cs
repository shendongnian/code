    /// <summary>Adds a single element to the end of an IEnumerable.</summary>
    /// <typeparam name="T">Type of enumerable to return.</typeparam>
    /// <returns>IEnumerable containing all the input elements, followed by the
    /// specified additional element.</returns>
    public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T element)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        return concatIterator(element, source, false);
    }
    /// <summary>Adds a single element to the start of an IEnumerable.</summary>
    /// <typeparam name="T">Type of enumerable to return.</typeparam>
    /// <returns>IEnumerable containing the specified additional element, followed by
    /// all the input elements.</returns>
    public static IEnumerable<T> Prepend<T>(this IEnumerable<T> tail, T head)
    {
        if (tail == null)
            throw new ArgumentNullException("tail");
        return concatIterator(head, tail, true);
    }
    private static IEnumerable<T> concatIterator<T>(T extraElement,
        IEnumerable<T> source, bool insertAtStart)
    {
        if (insertAtStart)
            yield return extraElement;
        foreach (var e in source)
            yield return e;
        if (!insertAtStart)
            yield return extraElement;
    }
