    public object ConvertSingleItem(string value, Type newType)
    {
        if (typeof(IConvertible).IsAssignableFrom(newType))
        {
            return Convert.ChangeType(value, newType);
        }
        else
        {
            // TODO: Add custom conversion for non IConvertible types
            var converter = CustomConvertersFactory.GetConverter(newType);
            return converter.Convert(value);
        }
    }
    public object ConvertStringToNewNonNullableType(string value, Type newType)
    {
        // Do conversion form string to array - not sure how array will be stored in string
        if (newType.IsArray)
        {
            // For comma separated list
            Type singleItemType = newType.GetElementType();
    
            var elements = new ArrayList();
            foreach (var element in value.Split(','))
            {
                var convertedSingleItem = ConvertSingleItem(element, singleItemType);
                elements.Add(convertedSingleItem);
            }
            return elements.ToArray(singleItemType);
        }
        return ConvertSingleItem(value, newType);
    }
    
    public object ConvertStringToNewType(string value, Type newType)
    {
        // If it's not a nullable type, just pass through the parameters to Convert.ChangeType
        if (newType.IsGenericType && newType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
        {
            if (value == null)
            {
                return null;
            }
            return ConvertStringToNewNonNullableType(value, new NullableConverter(newType).UnderlyingType);
        }
        return ConvertStringToNewNonNullableType(value, newType);
    }
            
    public object CallMethod(object instance, MethodInfo methodInfo, Dictionary<string, string> parameters)
    {
        var methodParameters = methodInfo.GetParameters();
          
        var parametersForInvocation = new List<object>();
        foreach (var methodParameter in methodParameters)
        {
            string value;
            if (parameters.TryGetValue(methodParameter.Name, out value))
            {
                var convertedValue = ConvertStringToNewType(value, methodParameter.ParameterType);
                parametersForInvocation.Add(convertedValue);
            }
            else
            {
                // Get default value of the appropriate type or throw an exception
                var defaultValue = Activator.CreateInstance(methodParameter.ParameterType);
                parametersForInvocation.Add(defaultValue);
            }
        }
        return methodInfo.Invoke(instance, parametersForInvocation.ToArray());
    }
