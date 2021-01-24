    public static IOrderedQueryable<TEntity> ThenById<TEntity>(
        this IOrderedQueryable<TEntity> source)
    {
        //snip
        var resultExpression = Expression.Call(
            typeof(System.Linq.Queryable),
            command,
            new Type[] { type, property.PropertyType },
            source.Expression,
            Expression.Quote(orderByExpression));
        return (IOrderedQueryable<TEntity>)source.Provider.CreateQuery<TEntity>(resultExpression);
    }
