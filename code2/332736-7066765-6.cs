    public static Expression<Func<T, bool>> BuildStringMatch<T>(Expression<Func<T, string>> property, string searchFor)
    {
        var searchForExpression = Expression.Constant(searchFor, typeof(string));
        return
            Expression.Lambda<Func<T, bool>>(
                Expression.OrElse(
                    Expression.Call(typeof(string), "IsNullOrEmpty", null, searchForExpression),
                    Expression.AndAlso(
                        Expression.NotEqual(property.Body, Expression.Constant(null, typeof(string))),
                        Expression.OrElse(
                            Expression.Call(Expression.Call(Expression.Call(property.Body, "Trim", null), "ToLower", null), "StartsWith", null,
                                Expression.Call(Expression.Call(searchForExpression, "Trim", null), "ToLower", null)),
                            Expression.Call(property.Body, "Contains", null, Expression.Call(typeof(string), "Concat", null, Expression.Constant(" "), searchForExpression))
                        )
                    )
                ),
                property.Parameters
            );
    }
