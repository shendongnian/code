    public static T ObjectWithMin<T, TResult>(this IEnumerable<T> elements, Func<T, TResult> projection)
            where TResult : IComparable<TResult>
        {
            if (elements == null) throw new ArgumentNullException("elements", "Sequence is null.");
            if (!elements.Any()) throw new ArgumentException("Sequence contains no elements.");
            var seed = elements.Select(t => new { Object = t, Projection = projection(t) }).First();
            return elements.Aggregate(seed,
                                      (s, x) =>
                                      projection(x).CompareTo(s.Projection) < 0
                                          ? new {Object = x, Projection = projection(x)}
                                          : s
                ).Object;
        }
