    IEnumerable<int> values = Enumerable.Range(0, 20)
        .Take(10); // Not necessary in this example
    foreach(var value in values)
    {
        Console.WriteLine(value);
    }
    // or ...
    foreach(var i in Enumerable.Range(0, 10))
    {
        Console.WriteLine(i * i);
    }
