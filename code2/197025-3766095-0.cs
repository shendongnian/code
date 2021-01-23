    Type iDict = T.GetType().GetInterface(typeof(IDictionary<,>).Name);
    if (iDict != null)
    {
        var genericParams = iDict.GetGenericArguments();
        Type tKey = genericParams[0], tValue = genericParams[1];
    }
