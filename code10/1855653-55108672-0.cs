    var keys = graph.Keys;
    // or, if you they were entered out of sequence and you want to sort them
    var keys = graph.Keys.OrderBy(k => k);
    // Now you're using the actual keys that are in the dictionary, so you'll never
    // try to access a missing key.
    foreach(var key in keys)
    {
        // It's not quite as clear to me what you're doing with these objects.
        // Suppose you wanted to print out everything:
        
        Console.WriteLine($"Key: {key}");
        
        foreach(var value in graph[key])
        {
            Console.WriteLine(value);
        }        
    }
