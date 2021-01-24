    Expression<Func<TModel, object>> GetPropertyExpression<TModel>(string propertyName) {
        // Manually build the expression tree for 
        // the lambda expression v => v.PropertyName.
        // (TModel v) =>
        var parameter = Expression.Parameter(typeof(TModel), "v");
        // (TModel v) => v.PropertyName
        var property = Expression.Property(parameter, propertyName);
        // (TModel v) => (object) v.PropertyName
        var cast = Expression.Convert(property, typeof(object));
        var expression = Expression.Lambda<Func<TModel, object>>(cast, parameter);
        return expression;
    }
