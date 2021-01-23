    public static T ObjectWithMax<T, TResult>(this IEnumerable<T> elements, Func<T, TResult> projection)
        where TResult : IComparable<TResult>
    {
        if (elements == null) throw new ArgumentNullException("elements", "Sequence is null.");
        if (!elements.Any()) throw new ArgumentException("Sequence contains no elements.");
        //Set up the "seed" (current known maximum) to the first element
        var seed = elements.Select(t => new {Object = t, Projection = projection(t)}).First();
        //run through all other elements of the source, comparing the projection of each
        //to the current "seed" and replacing the seed as necessary. Last element wins ties.
        return elements.Skip(1).Aggregate(seed,
                                  (s, x) =>
                                  projection(x).CompareTo(s.Projection) >= 0
                                      ? new {Object = x, Projection = projection(x)}
                                      : s
            ).Object;
    }
    public static T ObjectWithMin<T, TResult>(this IEnumerable<T> elements, Func<T, TResult> projection)
        where TResult : IComparable<TResult>
    {
        if (elements == null) throw new ArgumentNullException("elements", "Sequence is null.");
        if (!elements.Any()) throw new ArgumentException("Sequence contains no elements.");
        var seed = elements.Select(t => new {Object = t, Projection = projection(t)}).First();
        //ties won by the FIRST element in the Enumerable
        return elements.Aggregate(seed,
                                  (s, x) =>
                                  projection(x).CompareTo(s.Projection) < 0
                                      ? new {Object = x, Projection = projection(x)}
                                      : s
            ).Object;
    }
