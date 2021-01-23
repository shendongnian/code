    public static void Main (string[] args)
    {
        decimal d = 3.1M;
        Console.WriteLine((d % 1) == 0);
        d = 3.0M;
        Console.WriteLine((d % 1) == 0);
    }
