    private Expression<Func<TDto, bool>> GetObjectAsExpression<TSearchDto, TDto>(TSearchDto searchDto)
        where TSearchDto : class where TDto : class
    {
        ParameterExpression singleParameterExpression = Expression.Parameter(typeof(TDto), "node");
        Expression predicateBody = Expression.Constant(true);
        foreach (PropertyInfo property in searchDto.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            Expression left = Expression.Property(singleParameterExpression, property.Name);
            Expression expression = Expression.Equal(left, Expression.Constant(property.GetValue(searchDto)));
            predicateBody = Expression.And(predicateBody, expression);
        }
        return Expression.Lambda<Func<TDto, bool>>(
            predicateBody,
            singleParameterExpression
        );
    }
