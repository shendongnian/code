    public static void DoIt(string a)
    {
        Console.WriteLine(a);
    }
    public static void Main(string[] args)
    {
        List<string> symbolList = new List<string>() { "AAPL", "QQQ", "FB", "MSFT", "IBM" };
        Parallel.ForEach(symbolList, a => DoIt(a));
    }
