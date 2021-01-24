    public void TestMethod(object? o)
    {
        Ensure.True(o != null);
        Console.WriteLine(o.ToString()); // No warning
    }
