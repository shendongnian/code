    // static for caching & performance 
    private static MethodInfo efPropertyGenericMethod = typeof(EF).GetTypeInfo().GetDeclaredMethod("Property");
    Expression SortBy(object entity, Type type, string propertyName)
    {
        // set T generic type here for EF.Property<T>
        var efPropertyMethod = efPropertyGenericMethod.MakeGenericMethod(type);
        Expression lambda = Expression.Lambda(
            Expression.Call(null, efPropertyMethod, Expression.Constant(propertyName, typeof(string))),
            Expression.Parameter(type, "x")
        );
        return lambda;
    };
