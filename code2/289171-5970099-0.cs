    public bool ShouldMap(Assembly mappingAssembly, Type type)
    {
        Type classMapType = typeof(ClassMap<>).MakeGenericType(new[] { type });
        return mappingAssembly.GetTypes().Contains(classMapType);
    }
