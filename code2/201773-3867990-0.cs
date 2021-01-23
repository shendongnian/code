    static Array ConvertAll<TSource, TResult>(this Array source,
                                              Converter<TSource, TResult> projection)
    {
        if (!typeof (TSource).IsAssignableFrom(source.GetType().GetElementType()))
        {
            throw new ArgumentException();
        }
        var dims = Enumerable.Range(0, source.Rank)
            .Select(dim => new {lower = source.GetLowerBound(dim),
                                upper = source.GetUpperBound(dim)});
        var result = Array.CreateInstance(typeof (TResult),
            dims.Select(dim => 1 + dim.upper - dim.lower).ToArray(),
            dims.Select(dim => dim.lower).ToArray());
        var indices = dims
            .Select(dim => Enumerable.Range(dim.lower, 1 + dim.upper - dim.lower))
            .Aggregate(
                (IEnumerable<IEnumerable<int>>) null,
                (total, current) => total != null
                    ? total.SelectMany(
                        item => current,
                        (existing, item) => existing.Concat(new[] {item}))
                    : current.Select(item => (IEnumerable<int>) new[] {item}))
            .Select(index => index.ToArray());
        foreach (var index in indices)
        {
            var value = (TSource) source.GetValue(index);
            result.SetValue(projection(value), index);
        }
        return result;
    }
