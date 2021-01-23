    var x = new[]
    {
        new { Name = "Alice", Score = 50 },
        new { Name = "Bob", Score = 40 },
        new { Name = "Cathy", Score = 45 }
    };
    var y = x.ToDictionary(i => i.Name);
