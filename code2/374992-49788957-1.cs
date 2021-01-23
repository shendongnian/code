    public static Type ToType(Type type, ITypeResolver typeResolver)
    {    
        Assembly assembly = Assembly.Load(SerializableType.AssemblyName);
        type = typeResolver.GetType(assembly, sType.AssemblyQualifiedName);
    }
