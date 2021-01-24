    return source.Provider.CreateQuery(
        Expression.Call(
            typeof(Queryable),
            "GroupBy", 
            new Type[] { source.ElementType, keyLambda.Body.Type, elementLambda.Body.Type },
            source.Expression,
            Expression.Quote(keyLambda),
            Expression.Quote(elementLambda),
            Expression.Constant(StringComparer.InvariantCultureIgnoreCase)
        )
    );
