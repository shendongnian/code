    IEnumerable<Type> interfaces;
    try
    {
        interfaces = _assembly.GetTypes().Where(x => x.IsInterface);
    }
    catch (ReflectionTypeLoadException ex)
    {
        interfaces = ex.Types.Where(x => x != null && x.IsInterface);
    }
