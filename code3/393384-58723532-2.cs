    List<Type> typesImplementingIRepository = new List<Type>();
    IEnumerable<Type> allTypesInThisAssebly = Assembly.GetExecutingAssembly().GetTypes();
    foreach (Type type in allTypesInThisAssebly)
    {
        if (type.GetInterface(typeof(IRepository<>).Name.ToString()) != null)
        {
            typesImplementingIRepository.Add(type);
        }
    }
