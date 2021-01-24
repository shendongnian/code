    static void Main(string[] args)
    {
        var array = new[] { 1, 2, 3 };
        Console.WriteLine("ForEach:");
        array.ForEach(a => Console.WriteLine(a));
        
        // add this line
        foreach (var b in array.ForEach(a => Console.WriteLine(a))) { }
        
        Console.WriteLine("ForEach2:");
        array.ForEach2(a => Console.WriteLine(a));
        Console.ReadKey();
    }
