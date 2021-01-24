    public static object InvokeWithOrderedParameters(object instance, string methodName,
        IDictionary<string, object> namedParameters)
    {
        // Get the method to invoke
        var method = instance.GetType().GetMethod(methodName);
        // Get an array of ordered parameter values based on the specified named 
        // parameters, with a default value of "Type.Missing" for any missing names 
        var orderedParams = method.GetParameters().Select(param =>
        {
            object value;
            // Set the value from our dictionary, or if that fails use "Type.Missing"
            if (!namedParameters.TryGetValue(param.Name, out value))
            {
                value = Type.Missing;
            }
            return value;
        }).ToArray();
        // Invoke the method with the ordered parameters and return the value
        return method.Invoke(instance, orderedParams);
    }
