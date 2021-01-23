    public bool ShouldMap(Assembly mappingAssembly, Type type)
    {
        Type classMapType = typeof(ClassMap<>).MakeGenericType(type);
        return mappingAssembly.GetTypes().Any(t => t.IsSubclassOf(classMapType));
    }
