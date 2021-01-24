    foreach (var item in new string[] { "cat", "dog", "mouse" })
    {
        // This works
        Console.WriteLine($"{item, -12}");
    
        // This does not work
        const int pad = -12;
        Console.WriteLine($"{item, pad}");
    }
