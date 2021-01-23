    var type = typeof (T);
    if (typeof (IDictionary).IsAssignableFrom(type))
    {
        //non-generic dictionary
    }
    else if (type.IsGenericType &&
             type.GetGenericTypeDefinition() == typeof (IDictionary<,>))
    {
        //generic dictionary interface
    }
    else if (type.GetInterfaces().Any(
                i => i.IsGenericType &&
                     i.GetGenericTypeDefinition() == typeof (IDictionary<,>)))
    {
        //implements generic dictionary
    }
