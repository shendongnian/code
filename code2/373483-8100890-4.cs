    var items = new[]
        {
            // Range 1
            new { A = 0, B = 1 },
            new { A = 1, B = 2 },
            new { A = 2, B = 3 },
            new { A = 3, B = 4 },
            // Range 2
            new { A = 5, B = 6 },
            new { A = 6, B = 7 },
            new { A = 7, B = 8 },
            new { A = 8, B = 9 },
        };
    var ranges = items.ContinousRange(
        x => x.A,
        x => x.B,
        (lower, upper) => new { A = lower, B = upper });
    foreach(var range in ranges)
    {
        Console.WriteLine("{0} - {1}", range.A, range.B);
    }
