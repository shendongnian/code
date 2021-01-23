    var groups = collections.GroupBy(x => new { x.E1, x.E2, x.E3 });
    foreach (var group in groups)
    {
        Console.WriteLine("Key: {0}", group.Key);
        foreach (var item in group)
        {
            Console.WriteLine("  ID: {0}", item.ID);
        }
    }
