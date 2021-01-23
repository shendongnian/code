    private static IQueryable<TSource> BuildQuery<TSource, TProperty>(
        IQueryable<TSource> query,
        string methodName,
        Expression<Func<TSource, TProperty>> property)
    {
        var typeArguments = property.Type.GetGenericArguments();
        var methodCall = Expression.Call(
            typeof(Queryable),
            methodName,
            typeArguments,
            query.Expression,
            property);
        return query.Provider.CreateQuery<TSource>(methodCall);
    }
