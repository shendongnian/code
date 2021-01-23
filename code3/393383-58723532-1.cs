    List<Type> typesImplementingIRepository = new List<Type>();
    // load all types in this assembly
    IEnumerable<Type> typesInThisAssebly = Assembly.GetExecutingAssembly().GetTypes();
    // look for types that implement IRepository<>
    foreach (Type type in typesInThisAssebly)
    {
        if (type.GetInterface(typeof(IRepository<>).Name.ToString()) != null)
        {
            typesImplementingIRepository.Add(type);
        }
    }
