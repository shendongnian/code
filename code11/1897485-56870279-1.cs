    var source = new List<(DateTime From, DateTime To)>()
    {
        (new DateTime(2019, 1, 10), new DateTime(2019, 1, 12)),
        (new DateTime(2019, 3, 10), new DateTime(2019, 3, 14)),
        (new DateTime(2019, 1, 12), new DateTime(2019, 1, 13)),
        (new DateTime(2019, 3, 5), new DateTime(2019, 3, 10)),
    };
    var consolidated = source
        .Consolidate(r => r.From, r => r.To, (r1, r2) => (r1.From, r2.To))
        .OrderBy(r => r.From)
        .ToList();
    foreach (var range in consolidated)
    {
        Console.WriteLine($"{range.From:yyyy-MM-dd} => {range.To:yyyy-MM-dd}");
    }
