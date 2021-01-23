    var type = Type.GetType("ObjectDataAccessBase");
    type = type.MakeGenericType(Type.GetType("Your T as string"));
    var repository = Activator.CreateInstance(type);
    
    var method = type.GetMethod("Get");
    var result = method.Invoke(repository, new object[]{ id });
