    public static IQueryOver<T, T> WhereInOpenEndedDateRange<T>(this IQueryOver<T, T> query,
        Expression<Func<T, DateTime?>> expression,
        DateTime? rangeFrom,
        DateTime? rangeTo) where T : class
    {
        // Lambda being sent in
        ParameterExpression param = expression.Parameters.Single();
        if(rangeFrom.HasValue && rangeTo.HasValue)
        {
            // GT Comparison
            var expressionGT =
                Expression.GreaterThanOrEqual(
                    expression.Body,
                    Expression.Constant(rangeFrom.Value, typeof(DateTime?)
                )
            );
            // LT Comparison
            var expressionLT =
                Expression.LessThanOrEqual(
                    expression.Body,
                    Expression.Constant(rangeTo.Value, typeof(DateTime?)
                )
            );
            query.Where(
                   Expression.Lambda<Func<T, bool>>(expressionGT, param))
                   .And(
                   Expression.Lambda<Func<T, bool>>(expressionLT, param)
            );
        }
        else if(rangeFrom.HasValue)
        {
            // GT Comparison
            BinaryExpression expressionGT =
                Expression.GreaterThanOrEqual(
                    expression.Body,
                    Expression.Constant(rangeFrom.Value, typeof(DateTime?)
                )
            );
            // covert to lambda
            query.Where(Expression.Lambda<Func<T, bool>>(expressionGT, param));
        }
        else if(rangeTo.HasValue)
        {
            // LT Comparison
            BinaryExpression expressionLT =
                Expression.LessThanOrEqual(
                    expression.Body,
                    Expression.Constant(rangeTo.Value, typeof(DateTime?)
                )
            );
            query.Where(Expression.Lambda<Func<T, bool>>(expressionLT, param));
        }
        return query;
    }
