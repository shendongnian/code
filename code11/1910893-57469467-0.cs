    static void TestMethod<T>(T value) where T : ISomeInterface
    {
        var props1 = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var p in props1)
        {
            Console.WriteLine("Using typeof(T): {0}", p.Name);
        }
        var props2 = value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var p in props2)
        {
            Console.WriteLine("Using value.GetType(): {0}", p.Name);
        }
    }
