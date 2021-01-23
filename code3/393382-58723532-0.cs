    List<Type> typesImplementingIRepository = new List<Type>();
    // load all types in this assembly
    IEnumerable<Type> typesInThisAssebly = Assembly.GetExecutingAssembly().GetTypes();
    foreach (Type type in typesInThisAssebly)
    {
        if (type.IsGenericType == true && type.GetGenericTypeDefinition() == typeof(IRepository<>))
        {
            typesImplementingIRepository.Add(type);
        }
    }
