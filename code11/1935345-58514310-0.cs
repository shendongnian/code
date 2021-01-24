    public object ConvertValue(object value, Type targetType){
        var valueType = value.GetType();
        // Func<TValue,TTarget>
        var delegateType = typeof(Func<,>).MakeGenericType(valueType, targetType);
        var convert = typeof(Convert).GetMethod("ChangeType", new[] { typeof(object), typeof(Type) });
        // TValue p
        var parameter = Expression.Parameter(valueType, "p");
        // Convert.ChangeType(Convert(p), targetType);
        var changeType = Expression.Call(convert, Expression.Convert(parameter, typeof(object)), Expression.Constant(targetType));
        // (TTarget)Convert.ChangeType(Convert(p), targetType);
        var body = Expression.Convert(changeType, targetType);
        //Func<TValue,TTarget> = TValue p => (TTarget)Convert.ChangeType(Convert(p), targetType);
        var lambda = Expression.Lambda(delegateType, body, parameter);
        var method = lambda.Compile();
        var result = method.DynamicInvoke(value);
        return result;
    }
