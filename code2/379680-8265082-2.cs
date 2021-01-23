    static Expression<Func<T, bool>> GetTime<T>(
        Expression<Func<T, DateTime>> expression, 
        DateTime compare
    )
    {
        var comparison = Expression.AndAlso(
            Expression.AndAlso(
                Expression.GreaterThanOrEqual(
                    Expression.Property(expression.Body, "Year"),
                    Expression.Constant(compare.Year)
                ),
                Expression.GreaterThanOrEqual(
                    Expression.Property(expression.Body, "Month"),
                    Expression.Constant(compare.Month)
                )
            ),
            Expression.GreaterThanOrEqual(
                Expression.Property(expression.Body, "Day"),
                Expression.Constant(compare.Day)
            )
        );
        return Expression.Lambda<Func<T, bool>>(comparison, expression.Parameters);
    }
