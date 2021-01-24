    // Single Value
    Console.Write(LongName<MyEnum>(1));
    // All Values (array with 4 items)
    Console.Write(string.Join(", ", LongNames<MyEnum>())); 
    // All Values combined (array with 2 items)
    Console.Write(string.Join(", ", LongNames<MyEnum>())); 
