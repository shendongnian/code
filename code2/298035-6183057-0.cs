    var items = new[]
    {
        new { SrNo = 1, Roll = 1, Name = "XYZ" },
        new { SrNo = 99, Roll = 45, Name = "ABC" },
        new { SrNo = 150, Roll = 120, Name = "POQ" },
        new { SrNo = 10, Roll = 9, Name = "RTY" }
    };
    var ranges = items
        .GroupBy(arg => arg.SrNo / 100)
        .Select(arg => new { Range = arg.Key, Items = arg.ToList() })
        .ToList();
