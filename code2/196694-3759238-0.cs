    /// <summary>
    /// Splits the specified IEnumerable at every element that satisfies a
    /// specified predicate and returns a collection containing each sequence
    /// of elements in between each pair of such elements. The elements
    /// satisfying the predicate are not included.
    /// </summary>
    /// <param name="splitWhat">The collection to be split.</param>
    /// <param name="splitWhere">A predicate that determines which elements
    /// constitute the separators.</param>
    /// <returns>A collection containing the individual pieces taken from the
    /// original collection.</returns>
    public static IEnumerable<IEnumerable<T>> Split<T>(
            this IEnumerable<T> splitWhat, Func<T, bool> splitWhere)
    {
        if (splitWhat == null)
            throw new ArgumentNullException("splitWhat");
        if (splitWhere == null)
            throw new ArgumentNullException("splitWhere");
        return splitIterator(splitWhat, splitWhere);
    }
    private static IEnumerable<IEnumerable<T>> splitIterator<T>(
            IEnumerable<T> splitWhat, Func<T, bool> splitWhere)
    {
        int prevIndex = 0;
        foreach (var index in splitWhat
            .Select((elem, ind) => new { e = elem, i = ind })
            .Where(x => splitWhere(x.e)))
        {
            yield return splitWhat.Skip(prevIndex).Take(index.i - prevIndex);
            prevIndex = index.i + 1;
        }
        yield return splitWhat.Skip(prevIndex);
    }
