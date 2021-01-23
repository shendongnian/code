    var items = 
        new[]
        {
            new { SrNo = 1, Roll = 1, Name = "XYZ" },
            new { SrNo = 99, Roll = 45, Name = "ABC" },
            new { SrNo = 150, Roll = 120, Name = "POQ" },
            new { SrNo = 10, Roll = 9, Name = "RTY" }
        };
    const int NumberOfItemsInRange = 100;
    var ranges = items
        .GroupBy(arg => arg.SrNo / NumberOfItemsInRange)
        .Select(arg => new { RangeNumber = arg.Key, Items = arg.ToList() })
        .ToList();
    foreach (var range in ranges)
    {
        Console.WriteLine("Range {0}-{1}", range.RangeNumber * NumberOfItemsInRange, (range.RangeNumber + 1) * NumberOfItemsInRange);
        foreach (var item in range.Items)
            Console.WriteLine("{0,10} {1,10} {2,10}", item.SrNo, item.SrNo, item.Name);
    }
