    void Main()
    {
        Console.WriteLine(getContructor<object>()());
        Console.WriteLine(getContructor<int>()());
        Console.WriteLine(getContructor<string>()());
        Console.WriteLine(getContructor<decimal>()());
        Console.WriteLine(getContructor<DateTime>()());
        Console.WriteLine(getContructor<int?>()());
    }
