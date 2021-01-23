    public static CartesianType CreateInstance(string fullyQualifiedClassName)
    {
         Assembly assembly= Assembly.GetExecutingAssembly();
         Type target = assembly.GetType(fullyQualifiedClassName, true, true);
    
         return (CartesianType)Activator.CreateInstance(target);
    }
