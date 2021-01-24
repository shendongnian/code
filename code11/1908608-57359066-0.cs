    var all = new (string Name, Func<string> Check)[]
    {
        ("type1", checkfortype2),
        ("type4", checkfortype4),
        ("type3", checkfortype3),
        ("type5", checkfortype5),
    };
    var foundType = all
        .Where(type => type.Check(input))
        .Select(type => type.Name)
        .DefaultIfEmpty("None")
        .First();
    Console.WriteLine($"Input is of type: {foundType.Name}");
