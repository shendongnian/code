    // Grouping
    var groups = products.GroupBy(x => x.Type);
    foreach (var group in groups)
    {
        Console.WriteLine("Group " + group.Key);
        foreach (var product in group)
        {
            // This will only enumerate over items that are in the group.
        }
    }
    // Ordering
    var ordered = products.OrderBy(x => x.Type);
    foreach (var product in ordered)
    {
        // This will enumerate all the items, regardless of the group,
        // but the items will be arranged so that the items with the same
        // group are collected together
    }
