    // Items to process.
    List<string> names = new List<string>() { 
        "Joe", "Bob", "Fred", "Jack", "Jill", "Suzy", "Amy", "Alice", 
        "Andy", "Bill", "Chuck" };
    
    // Process using Parallel LINQ
    names.AsParallel().ForAll(name =>
    {
        var id = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine(string.Concat(id, ": Putting ", name, " in the database."));
        Thread.Sleep(rnd.Next(1000, 5000));
    });
