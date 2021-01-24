    public static Expression<Func<TModel, object>> GetPropertyExpression<TModel>(this IEnumerable<TModel> model, string propertyName) {
        // Manually build the expression tree for 
        // the lambda expression m => m.PropertyName.
        // (TModel m) =>
        var parameter = Expression.Parameter(typeof(TModel), "m");
        // (TModel m) => m.PropertyName
        var property = Expression.PropertyOrField(parameter, propertyName);
        // (TModel m) => (object) m.PropertyName
        var cast = Expression.Convert(property, typeof(object));
        var expression = Expression.Lambda<Func<TModel, object>>(cast, parameter);
        return expression;
    }
