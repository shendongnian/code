    public T test<T>(T input)
    {
        return input;
    }
    void Main()
    {
        Console.WriteLine(test(true));
        Console.WriteLine(test(1));
        Console.WriteLine(test("Steve"));
    }
