    static readonly MethodInfo ChangeTypeMethod = typeof(Convert).GetMethod(
        "ChangeType", new[] { typeof(object), typeof(Type) });
    static Expression<Func<T, bool>> LabmdaExpression<T>(
        string property1, string value1, Type propertyType)
    {
        ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "o");
        MemberExpression memberExpression1 = Expression.PropertyOrField(
            parameterExpression, property1);
        Expression convertedObject = Expression.Call(
            ChangeTypeMethod, Expression.Constant(value1),
            Expression.Constant(propertyType));
        Expression converted = Expression.Convert(convertedObject, propertyType);
        BinaryExpression binaryExpression1 = Expression.GreaterThan(
            memberExpression1, converted);
        return Expression.Lambda<Func<T, bool>>(binaryExpression1, parameterExpression);
    }
