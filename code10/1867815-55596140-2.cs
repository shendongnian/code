    public static void SetEntityValue(TDBTable entity, Expression<Func<TDBTable, object>> expression, object value)
    {
        ParameterExpression valueParameterExpression = Expression.Parameter(typeof(object));
        Expression targetExpression = expression.Body is UnaryExpression ? ((UnaryExpression)expression.Body).Operand : expression.Body;
        var newValue = Expression.Parameter(expression.Body.Type);
        var assign = Expression.Lambda<Action<TDBTable, object>>
        (
            Expression.Assign(targetExpression, Expression.Convert(valueParameterExpression, targetExpression.Type)),
            expression.Parameters.Single(),
            valueParameterExpression
        );
        assign.Compile().Invoke(entity, value);
    }
