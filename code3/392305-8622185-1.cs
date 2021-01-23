    [Retry(2)]
    public static void DoIt()
    {
        Console.WriteLine("tried");
        throw new Exception();
    }
