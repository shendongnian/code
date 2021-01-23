    var type = typeof(XClass<,>); 
    var method = type.GetMethod("MethodA");
    Type[] types = new Type[2];
    types[0] = typeof(int);
    types[1] = type.GetGenericArguments()[1]; // Use the open parameter type
    var openConstructedType = type.MakeGenericType(types);
