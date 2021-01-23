    public static IQueryable Where(this IQueryable source, string predicate, params object[] values) {
        if (source == null) throw new ArgumentNullException("source");
        if (predicate == null) throw new ArgumentNullException("predicate");
        LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(bool), predicate, values);
        return source.Provider.CreateQuery(
            Expression.Call(
                typeof(Queryable), "Where",
                new Type[] { source.ElementType },
                source.Expression, Expression.Quote(lambda)));
    }
