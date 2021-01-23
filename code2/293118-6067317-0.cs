    var dict = new Dictionary<int, string>();
    string result;
    if (dict.TryGetValue(1, out result))
    {
        Console.WriteLine("Key 1 exists: " + result);
    }
    else
    {
        Console.WriteLine("Key 1 not found");
    }
    
    dict[1] = "hi";
    dict[1] = "hello";
    Console.WriteLine(dict[1]);
    
    if (dict.TryGetValue(1, out result))
    {
        Console.WriteLine("Key 1 exists: " + result);
    }
    else
    {
        Console.WriteLine("Key 1 not found");
    }
