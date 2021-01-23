    static void Main(string[] args)
    {
        var o = new ReplaySubject<string>();
    
        o.OnNext("blueberry");
        o.OnNext("chimpanzee");
        o.OnNext("abacus");
        o.OnNext("banana");
        o.OnNext("apple");
        o.OnNext("cheese");
    
        var latest = o.Where(i => i.StartsWith("b"))
            .Replay(1)
            .First();
    
        Console.WriteLine(latest);
    
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
