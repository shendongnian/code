        Expression<Func<TEntity, object>> CreateLambda<TEntity>(PropertyInfo propertyInfo) where TEntity : class
        {
            var parameterExpression = System.Linq.Expressions.Expression.Parameter(typeof(TEntity), "x");
            var memberExpression = System.Linq.Expressions.Expression.PropertyOrField(parameterExpression, propertyInfo.Name);
            var memberExpressionConversion = System.Linq.Expressions.Expression.Convert(memberExpression, typeof(object));
            return System.Linq.Expressions.Expression.Lambda<Func<TEntity, object>>(memberExpressionConversion, parameterExpression);
        }
    ...
    _unitOfWork.Session.Query<TEntity>().Fetch(CreateLambda<TEntity>(property)).ToFuture();
    ...
