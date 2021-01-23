    private static void PrintTypes(params dynamic[] args)
    {
        foreach (var arg in args)
        {
            Console.WriteLine(arg.GetType());
        }
    }
    static void Main(string[] args)
    {
        PrintTypes(1,1.0,"hello");
        Console.ReadKey();
    }
