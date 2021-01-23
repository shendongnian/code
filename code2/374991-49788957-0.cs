    public static Type ToType(Type sType)
    {    
        Assembly assembly = Assembly.Load(SerializableType.AssemblyName);
        type = assembly.GetType(sType.AssemblyQualifiedName);
    }
