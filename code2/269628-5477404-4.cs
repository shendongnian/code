    public object CreateType(System.Type type)
    {
        Type typeFactory = typeof(TypeFactory);
        MethodInfo m = typeFactory.GetMethod("Create").MakeGenericMethod(type);
        return m.Invoke(null, null);
    }
