    public static void Main()
    {
        // Func<int,int,int> is a delegate which accepts two
        // int parameters and returns int as a result
        Func<int, int, int> op = (a, b) => a + b;
        Console.WriteLine(op(1, 2));
    }
