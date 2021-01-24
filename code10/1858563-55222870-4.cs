    // static for caching & performance 
    static private MethodInfo efPropertyGenericMethod = typeof(EF).GetTypeInfo().GetDeclaredMethod("Property");
    Expression SortBy(object entity, Type type, string propertyName)
    {
        var xParam = Expression.Parameter(type, "x");
        // set T generic type here for EF.Property<T>
        var efPropertyMethod = efPropertyGenericMethod.MakeGenericMethod(type);
        // Creates a Lambda
        Expression lambda = Expression.Lambda(
            // Calls a method. First parameter is null for static calls
            Expression.Call(null,
                efPropertyMethod, // our cosntructed generic Version of EF.Property<T>
                xParam, // Pass the x Parameter
                Expression.Constant(propertyName, typeof(string)) // the propertyName asconstant
            ),
            xParam
        );
        return lambda;
    };
