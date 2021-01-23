    Console.WriteLine(propInfoOne.PropertyType.IsPrimitive); //true
    Console.WriteLine(propInfoOne.PropertyType.IsValueType); //false, value types are structs
    
    Console.WriteLine(propInfoThree.PropertyType.IsEnum); //true
    
    var nullableType = typeof (Nullable<>).MakeGenericType(propInfoThree.PropertyType);
    Console.WriteLine(nullableType.IsAssignableFrom(propInfoThree.PropertyType)); //true
