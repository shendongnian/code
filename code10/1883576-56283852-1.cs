    private enum Integers
    {
        int1 = 50,
        int2 = 42,
        // etc.
    }
    foreach (var value in Enum.GetValues(typeof(Integers)).Cast<int>())
    {
        Console.WriteLine(value);
    }
