    public static IQueryable Take(this IQueryable source, int count)
    {
        MethodCallExpression mce = Expression.Call(
            typeof(Queryable),
            "Take",
            new Type[] { source.ElementType },
            source.Expression,
            Expression.Constant(count)
        );
        return source.Provider.CreateQuery(mce);
    }
