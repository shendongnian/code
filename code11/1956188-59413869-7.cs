      static Dictionary<Tuple<Type, string>, string> s_Dictionary = Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Where(t => t.IsAbstract && t.IsSealed) 
        ...
