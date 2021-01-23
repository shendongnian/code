    private static IQueryable<T> BuildQuery<T>(
        IQueryable<T> query,
        string methodName,
        Expression<Func<T, object>> property)
    {
        var typeArgs = new[] { query.ElementType, property.Body.Type };
        var delegateType = typeof(Func<,>).MakeGenericType(typeArgs);
        var typedProperty = Expression.Lambda(delegateType, property.Body, property.Parameters);
        var methodCall = Expression.Call(
            typeof(Queryable),
            methodName,
            typeArgs,
            query.Expression,
            typedProperty);
        return query.Provider.CreateQuery<T>(methodCall);
    }
