    Console.WriteLine(IsDefault<int>(0));     // False
    Console.WriteLine(IsNull<int>(0));        // False
    Console.WriteLine(IsDefault<int?>(null)); // True
    Console.WriteLine(IsNull<int?>(null));    // True
    Console.WriteLine(IsDefault<int?>(0));    // False
    Console.WriteLine(IsNull<int?>(0));       // False
