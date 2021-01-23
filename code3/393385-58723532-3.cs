    List<Type> typesImplementingIRepository = new List<Type>();
    IEnumerable<Type> allTypesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();
    foreach (Type type in allTypesInThisAssembly)
    {
        if (type.GetInterface(typeof(IRepository<>).Name.ToString()) != null)
        {
            typesImplementingIRepository.Add(type);
        }
    }
