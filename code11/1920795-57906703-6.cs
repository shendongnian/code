    public static void TestMethod(int? x, int? y)
    {
        if (x == null) x = 10;
        if (y == null) y = 10;
        string message = $"The value of x is {x.Value} and y is {y.Value}";
    }
