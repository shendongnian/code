    var items = new[] {
        new { ID = 1, Num = 100, Name = "foo" },
        new { ID = 1, Num = 203, Name = "foo" },
        new { ID = 2, Num = 400, Name = "bar" },
        new { ID = 3, Num = 10, Name = "cat" },
    };
    var result = items.GroupBy(x => x.ID, (k, i) => new { id = k, num = i.Select(y => y.Name).ToArray() });
