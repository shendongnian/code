    Type iDict = null;
    if (typeof(T).GetGenericTypeDefinition() == typeof(IDictionary<,>))
        iDict = typeof(T);
    else
        iDict = typeof(T).GetInterface(typeof(IDictionary<,>).Name);
    if (iDict != null)
    {
        var genericParams = iDict.GetGenericArguments();
        Type tKey = genericParams[0], tValue = genericParams[1];
    }
