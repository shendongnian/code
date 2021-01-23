    var dict = new Dictionary<int, string>();
    
    Console.WriteLine(dict.ContainsKey(1)); // false
    dict[1] = "hi";
    dict[1] = "hello"; // "hi" is overwritten
    
    // true: hello
    Console.WriteLine("{0}: {1}", dict.ContainsKey(1), dict[1]);
    
    // TryGetValue if checking by key and interested in the value
    string result;
    if (dict.TryGetValue(1, out result))
    {
        Console.WriteLine("Key 1 exists: " + result);
    }
    else
    {
        Console.WriteLine("Key 1 not found");
    }
