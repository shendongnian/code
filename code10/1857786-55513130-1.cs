    public static void Main()
    {
        var task = ExecuteQuery("1 Microsoft Way, Redmond, WA");
        task.Wait();
        Console.WriteLine(task.Result);
        Console.ReadLine();
    }
