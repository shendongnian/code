    var source = new int[]
    {
        3, 27, 53, 79, 113, 129, 134, 140, 141, 142, 145, 174, 191, 214, 284, 284
    };
    foreach (var g in source.GroupByProximity(5))
    {
        Console.WriteLine(string.Join(", ", g));
    }
