        var parameterExpression = Expression.Parameter(typeof(TEntity), "x");
        var memberExpression = Expression.PropertyOrField(parameterExpression, property.Name);
        var memberExpressionConversion = Expression.Convert(memberExpression, typeof(object));
        var lambda = Expression.Lambda<Func<TEntity, object>>(memberExpressionConversion, parameterExpression);
    ...
    _unitOfWork.Session.Query<TEntity>().Fetch(lambda).ToFuture();
    ...
