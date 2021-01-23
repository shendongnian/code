    Dictionary<string, Type> typecache = new Dictionary<string, Type>();
    
    // finding a type from say a string that points at a type in an assembly not referrenced
    // very costly but we can cache that
    Type myType = GetSomeTypeWithReflection();
    typecache.Add("myType", myType);
    
    // creating an instance you can use very costly
    MyThingy thingy = Activator.CreateInstance(typecache["myType"]);
