    static Expression<Func<R, O>> 
    CreatePropSelectorExpression<R,O>(IEnumerable<string> propertyName)
    {
        ParameterExpression parameter = Expression.Parameter(typeof(R));
        Expression selector = propertyName
             .Aggregate((Expression)parameter, 
                   (a, name) => Expression.PropertyOrField(a, name));
        return Expression.Lambda<Func<R,O>>(selector, parameter);
    }
 
