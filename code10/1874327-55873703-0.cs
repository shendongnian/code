    // your items
    var items = new Item[]
    {
        new Item(DateTime.Parse("2019-01-01"), DateTime.Parse("2019-01-01")),
        new Item(DateTime.Parse("2019-02-01"), DateTime.Parse("2019-02-02")),
        new Item(DateTime.Parse("2019-03-01"), DateTime.Parse("2019-03-01")),
        new Item(DateTime.Parse("2019-04-01"), DateTime.Parse("2019-05-02")),
        new Item(DateTime.Parse("2019-05-01"), DateTime.Parse("2019-05-01")),
        new Item(DateTime.Parse("2019-05-01"), DateTime.Parse("2019-05-01")),
        new Item(DateTime.Parse("2019-05-01"), DateTime.Parse("2019-05-01")),
        new Item(DateTime.Parse("2019-05-01"), DateTime.Parse("2019-05-01")),
        new Item(DateTime.Parse("2019-05-01"), DateTime.Parse("2019-05-01")),
    };
    
    // order the elements by DatePaid descending
    // the aggregate accumulator will contain the last DateEntered
    // and the list of elements out of order
    var outOfOrder = items.OrderByDescending(i => i.DatePaid)
        .Aggregate(
            new { LastDate = DateTime.MaxValue, Accumulator = new Item[0] },
            (a, i) => new { LastDate = i.DateEntered, Accumulator = i.DateEntered <= a.LastDate ? a.Accumulator : a.Accumulator.Concat(new[] { i }).ToArray() });
