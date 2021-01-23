    /// <summary>
    /// Returns the first element of a sequence, or a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">The <see cref="IEnumerable&lt;T&gt;"/> to return the first element of.</param>
    /// <param name="default">The default value to return if the sequence contains no elements.</param>
    /// <returns><paramref name="default"/> if <paramref name="source"/> is empty;
    /// otherwise, the first element in <paramref name="source"/>.</returns>
    public static T FirstOrDefault<T>(this IEnumerable<T> source, T @default)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        using (var e = source.GetEnumerator())
        {
            if (!e.MoveNext())
                return @default;
            return e.Current;
        }
    }
    /// <summary>
    /// Returns the first element of a sequence, or a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">The <see cref="IEnumerable&lt;T&gt;"/> to return the first element of.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="default">The default value to return if the sequence contains no elements.</param>
    /// <returns><paramref name="default"/> if <paramref name="source"/> is empty or if no element passes the test specified by <paramref name="predicate"/>;
    /// otherwise, the first element in <paramref name="source"/> that passes the test specified by <paramref name="predicate"/>.</returns>
    public static T FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate, T @default)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (predicate == null)
            throw new ArgumentNullException("predicate");
        using (var e = source.GetEnumerator())
        {
            while (true)
            {
                if (!e.MoveNext())
                    return @default;
                if (predicate(e.Current))
                    return e.Current;
            }
        }
    }
