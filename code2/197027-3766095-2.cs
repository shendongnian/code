    Type iDict = T.GetType().GetInterfaces()
                  .Where(t => t.IsGenericType
                   && t.GetGenericTypeDefinition() == typeof(IDictionary<,>))
                  .FirstOrDefault();
    if (iDict != null)
    {
        var genericParams = iDict.GetGenericArguments();
        Type tKey = genericParams[0], tValue = genericParams[1];
    }
