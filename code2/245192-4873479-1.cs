    int? foo= 42;
    Console.WriteLine(foo.HasValue); // prints True
    Console.WriteLine(foo.Value); // prints 42
    int? bar = null;
    Console.WriteLine(bar.HasValue); // prints False
    Console.WriteLine(bar.Value); // throws InvalidOperationException
