    [Stopwatch]
    public string Search(string LineNo)
    {
        // Search for something
        // Is it possible to know how long (from Stopwatch attribute) Search took 
    }
    public void CallSearch
    {
        var stopwatch = StopwatchAttribute.Measure(() => {
            string x =  Search("xyz");
        });
        Console.WriteLine("Time elapsed: {0} ms", stopwatch.Elapsed);
    }
