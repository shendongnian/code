    public static IQueryable<T> AddEqualityCondition<T, V>(
        this IQueryable<T> queryable,
        Expression<Func<T, V>> selector, V propertyValue)
    {
        var lambda = Expression.Lambda<Func<T,bool>>(
           Expression.Equal(
               selector.Body,
               Expression.Constant(propertyValue, typeof(V)),
               false, typeof(T).GetMethod("op_Equality")),
            selector.Parameters);
        return queryable.Where(lambda);           
    }
