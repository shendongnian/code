    // From within the current assembly
    public CartesianType CreateInstance(string fullyQualifiedClassName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type target = assembly.GetType(fullyQualifiedClassName, true, true);
            
        return (CartesianType)Activator.CreateInstance(target);
    }
    
    // From an external assembly already referenced in your project
    public SomeClass CreateInstance(string fullyQualifiedClassName)
    {
        Assembly assembly = Assembly.GetAssembly(typeof(SomeClass));
        Type target = assembly.GetType(fullyQualifiedClassName, true, true);
            
        return (SomeClass)Activator.CreateInstance(target);
    }
