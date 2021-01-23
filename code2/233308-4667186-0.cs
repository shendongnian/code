    foreach (Type interfaceType in objectValue.GetType().GetInterfaces())
    {
        countProperty = interfaceType.GetProperty("Count");
        //etc.
    }
