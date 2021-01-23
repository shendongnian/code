    var value = Expression.Lambda<Func<TModel, string>>(
        Expression.MakeMemberAccess(
            expression.Body, 
            typeof(Foo).GetProperty("Value")
        ),
        expression.Parameters[0]
    );
    var list = Expression.Lambda<Func<TModel, string>>(
        Expression.MakeMemberAccess(
            expression.Body, 
            typeof(Foo).GetProperty("Section")
        ),
        expression.Parameters[0]
    );
