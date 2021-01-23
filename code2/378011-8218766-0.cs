    public static IEnumerable<int> UsingYield()
    {
        yield return 42;
    }
    public static IEnumerable<int> ReturningArray()
    {
        return new []{ 42 };
    }
