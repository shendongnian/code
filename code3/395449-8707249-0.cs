    string words = "Hello World This is a great world, This World is simply great".ToLower();
    
    var results = words.Split(' ').Where(x => x.Length > 3)
                                  .GroupBy(x => x)
                                  .OrderByDescending(x => x.Count());
    
    foreach (var item in results)
    {
        Console.WriteLine(item);
    }
    
    Console.ReadLine();
