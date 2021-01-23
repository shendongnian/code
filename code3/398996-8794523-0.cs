    var valExpression = Expression.Lambda<Func<Bar, T>>(
        Expression.PropertyOrField(baseExpression.Body, "Value"),
        baseExpression.Parameters);
    var updateExpression = Expression.Lambda<Func<Bar, bool>>(
        Expression.PropertyOrField(baseExpression.Body, "Update"),
        baseExpression.Parameters);
