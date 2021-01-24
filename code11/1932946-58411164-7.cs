    public void TestMethod(object? o)
    {
        Ensure.NotNull(o);
        Console.WriteLine(o.ToString()); // No warning
    }
