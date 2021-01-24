    public static object ConvertValue(object value, Type targetType) {
        var parameter = Expression.Parameter(typeof(object), "p"); // "p"
        var convert = Expression.Convert(Expression.Convert(parameter, value.GetType()), targetType); // Convert(p, Int64)
        var targetConvert = Expression.Convert(convert, typeof(object)); // Convert(Convert(p, Int64), Object)
        var lambda = Expression.Lambda<Func<object,object>>(targetConvert, parameter); // p => Convert(Convert(p, Int64), Object)
        var method = lambda.Compile();
        var result = method(value);
        return result;
    }
