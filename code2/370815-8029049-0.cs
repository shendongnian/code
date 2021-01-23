    private static readonly HashSet<Type> BuiltInTypes = new HashSet<Type>
    {
        typeof(object), typeof(string), typeof(byte), typeof(sbyte),
        // etc
    };
    // Then:
    if (BuiltInTypes.Contains(typeof(T)))
    {
        Console.WriteLine("It's a built-in type!");
    }
    else
    {
        Console.WriteLine("It's a custom class!");
    }
