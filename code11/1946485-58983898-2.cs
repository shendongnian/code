    //...omitted for brevity...
    else if (property.PropertyType.IsEnum) {
        var parameter = Expression.Parameter(typeof(T));
        var body = Expression.PropertyOrField(parameter, property.Name);
        var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), property.PropertyType);
        var propertyExpression = Expression.Lambda(delegateType, body, parameter);
        var value = convertToEnum(attribute.Value, property.PropertyType);
        var setup = mock.GetType().GetMethods()
            .FirstOrDefault(m => m.Name == "Setup" && m.ContainsGenericParameters)
            .MakeGenericMethod(property.PropertyType);
        var result = setup.Invoke(mock, new object[] { propertyExpression });
        var returns = result.GetType().GetMethod("Returns", new[] { property.PropertyType });
        returns?.Invoke(result, new object[] { value });
    }
    //...omitted for brevity...
