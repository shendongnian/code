    public static IQueryable ApplySearch(this IQueryable source, string search)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (string.IsNullOrWhiteSpace(search)) return source;
    
        var parameter = Expression.Parameter(source.ElementType, "e");
        var value = Expression.Property(Expression.Constant(new { search }), nameof(search));
        var body = SearchStrings(parameter, value);
        if (body == null) return source;
    
        var predicate = Expression.Lambda(body, parameter);
        var filtered = Expression.Call(
            typeof(Queryable), nameof(Queryable.Where), new[] { source.ElementType },
            source.Expression, Expression.Quote(predicate));
        return source.Provider.CreateQuery(filtered);
    }
