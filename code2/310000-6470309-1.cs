    if (query["c2"].Any(o => !String.IsNullOrEmpty(o)))
    {    
        // specific key: c2
        foreach (var item in query["c2"])
        {
            Console.WriteLine(item);
        }
    }
    else
    {
        Console.WriteLine("No valid results");
    }
