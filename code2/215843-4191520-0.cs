    Expression.Lambda<Func<object>>(
        Expression.Call(
            null,
            typeof(X).GetMethod("GetItem"),
            new Expression[] { Expression.Constant("123", typeof(string)) }
        ), 
        new ParameterExpression[0]
    );
