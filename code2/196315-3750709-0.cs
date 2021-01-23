    /// <summary>
    /// Returns all subsequences of the input <see cref="IEnumerable&lt;T&gt;"/>.
    /// </summary>
    /// <param name="source">The sequence of items to generate
    /// subsequences of.</param>
    /// <returns>A collection containing all subsequences of the input
    /// <see cref="IEnumerable&lt;T&gt;"/>.</returns>
    public static IEnumerable<IEnumerable<T>> Subsequences<T>(
            this IEnumerable<T> source)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        // Ensure that the source IEnumerable is evaluated only once
        return subsequences(source.ToArray());
    }
    private static IEnumerable<IEnumerable<T>> subsequences<T>(IEnumerable<T> source)
    {
        if (source.Any())
        {
            foreach (var comb in subsequences(source.Skip(1)))
            {
                yield return comb;
                yield return source.Take(1).Concat(comb);
            }
        }
        else
        {
            yield return Enumerable.Empty<T>();
        }
    }
