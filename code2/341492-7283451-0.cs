    if (typeOfProperty.IsGenericype)
    {
        Type genericDefinition = typeOfProperty.GetGenericTypeDefinition();
    
        if (genericDefinition == typeof(ICollection<>)
        {
            // Note that we're calling GetGenericArguments on typeOfProperty,
            // not genericDefinition.
            Type typeArgument = typeOfProperty.GetGenericArguments()[0];
            // typeArgument is now the type you want...
        }
    }
