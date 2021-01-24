    //...omitted for brevity...
    else if (property.PropertyType.IsEnum) {
        var parameter = Expression.Parameter(typeof(T));
        var body = Expression.PropertyOrField(parameter, property.Name);
        var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), property.PropertyType);
        var propertyExpression = Expression.Lambda(delegateType, body, parameter);
        var value = convertToEnum(attribute.Value, property.PropertyType);
        dynamic dynamicMock = mock;
        dynamicMock.Setup(propertyExpression).Returns(value);
    }
    //...omitted for brevity...
