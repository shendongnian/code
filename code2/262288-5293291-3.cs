    // group the MemObjects by Serial and ErrorCode that has more than 1 occurrences
    var query = list.GroupBy(mo => new { mo.Serial, mo.ErrorCode })
                    //.Where(g => g.Count() > 1); // O(n)
                    .Where(g => g.Skip(1).Any()); // O(1)
    // make the updates
    foreach (var group in query)
    {
        int i = 1;
        foreach (var mo in group)
        {
            mo.ModifedAt += TimeSpan.FromSeconds(i++);
        }
    }
