    object data = new Dictionary<string, object>
    {
        {"stringArr", new[] {"item1", "item2", "item3"}},
    };
    var parsedData = data as Dictionary<string, object>;
    // cast the object values to object[]
    foreach (object o in parsedData["stringArr"] as object[])  
    {
        Console.WriteLine(o.ToString());
    }
    // Output:
    // item1
    // item2
    // item3
