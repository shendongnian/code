    private static IEnumerable<Type> GetTypesSafely(Assembly assembly)
    {
        try
        {
            return assembly.GetTypes();
        }
        catch(ReflectionTypeLoadException ex)
        {
            return ex.Types.Where(x => x != null);
        }
    }
    
    ...
    IEnumberable<Type> interfaces = GetTypesSafely(_assembly).Where(x => x.IsInterface);
