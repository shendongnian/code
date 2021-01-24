    private static Expression<Func<T1, T2, bool>> CreateExpression<T1, T2>()
    {
        var t1 = Expression.Parameter(typeof(T1), "t1");
        var t2 = Expression.Parameter(typeof(T2), "t2");
        var idProp = Expression.PropertyOrField(t1, "Id");
        var nameProp = Expression.PropertyOrField(t2, "Name");
        var body = Expression.AndAlso(
            Expression.Equal(idProp, Expression.Constant(1)),
            Expression.Equal(nameProp, Expression.Constant("name"))
        );
        var lambda = Expression.Lambda<Func<T1, T2, bool>>(body, t1, t2);
        return lambda;
    }
