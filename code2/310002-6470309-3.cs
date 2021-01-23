    if (query["c1"].Any(o => !String.IsNullOrEmpty(o)))
    {    
        foreach (var item in query["c1"])
        {
            Console.WriteLine(item);
        }
    }
    else
    {
        Console.WriteLine("No valid results for c1");
    }
