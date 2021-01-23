    public static Func<object[], T> AnonymousInstantiator<T>(T example)
    {
        var ctor = typeof(T).GetConstructors().First();
        var paramExpr = Expression.Parameter(typeof(object[]));
        return Expression.Lambda<Func<object[], T>>
        (
            Expression.New
            (
                ctor,
                ctor.GetParameters().Select
                (
                    (x, i) => Expression.Convert
                    (
                        Expression.ArrayIndex(paramExpr, Expression.Constant(i)),
                        x.ParameterType
                    )
                )
            ), paramExpr).Compile();
    }
