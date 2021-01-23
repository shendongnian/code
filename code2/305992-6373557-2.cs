    // Enumerate all classes with the ContainsScriptableMethod like so
    foreach(var ClassWithAttribute in GetTypesWithAttribute(Assembly.GetExecutingAssembly(), typeof(ContainsScriptableMethodAttribute))
    {
        // Loop through each method in the class with the attribute
        foreach(var MethodWithAttribute in GetMethodsWithAttribute(ClassWithAttribute, ScriptableMethodAttribute))
        {
            // You now have information about a method that can be called. Use Attribute.GetCustomAttribute to get the ID of this method, then add it to a dictionary, or invoke it directly.
        }
    }
    static IEnumerable<Type> GetTypesWithAttribute(Assembly assembly, Type AttributeType)
    {
        foreach(Type type in assembly.GetTypes())
        {
            if (type.GetCustomAttributes(AttributeType, true).Length > 0)
            {
                yield return type;
            }
        }
    } 
    static IEnumerable<MethodInfo> GetMethodsWithAttribute(Type ClassType, Type AttributeType)
    {
        foreach(var Method in ClassType.GetMethods())
        {
            if (Attribute.GetCustomAttribute(AttributeType) != null)
            {
                yield Method;
            } 
       }
    }
