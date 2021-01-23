    public IEnumerable<Type> GetAllTypesDerivedFrom(Type type)
    {
        var types = Assembly.GetAssembly(type).GetTypes();
        return types.Where(t => t.IsSubclassOf(type));
    }
