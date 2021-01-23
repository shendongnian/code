    Type type = typeof(Derived);
    Type baseType = type.BaseType;
    if(baseType != null) {
        string baseTypeName = baseType.Name;
        Console.WriteLine(baseTypeName);
    }
    else {
        Console.WriteLine("No base type.");
    }
