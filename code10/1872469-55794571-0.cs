    public static List<Type> FindType<T>()
    {
        var types =
            from ssembly in AppDomain.CurrentDomain.GetAssemblies().AsParallel()
            from type in ssembly.GetTypes()
            let attributes = type.GetCustomAttributes(typeof(T), true)
            where attributes?.Length > 0
            select type;
        return types.ToList();
    }
