    // You can also obtain the generic type definition from a
    // constructed class. In this case, the constructed class
    // is a dictionary of Example objects, with String keys.
    Dictionary<string, Example> d2 = new Dictionary<string, Example>();
    // Get a Type object that represents the constructed type,
    // and from that get the generic type definition. The 
    // variables d1 and d4 contain the same type.
    Type d3 = d2.GetType();
    Type d4 = d3.GetGenericTypeDefinition();
