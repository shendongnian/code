    var testType = typeof(Outer<string>.Inner<int>);              
    var outerType = testType.DeclaringType;                       
    var outerTypeGenericParam = outerType.GetGenericArguments();
    var testTypeGenericParam = testType.GetGenericArguments();
    Console.WriteLine(outerType);                                 // Test+Outer`1[T] 
    Console.WriteLine(outerTypeGenericParam[0]);                  // T
    Console.WriteLine(testTypeGenericParam[0]);                   // System.String
    Console.WriteLine(testTypeGenericParam[1]);                   // System.Int32
