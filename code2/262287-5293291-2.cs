    // group the MemObjects by Serial and ErrorCode
    var query = list.GroupBy(mo => new { mo.Serial, mo.ErrorCode })
                    .Where(g => g.Count() > 1);
    // make the updates
    foreach (var group in query)
    {
        int i = 1;
        foreach (var mo in group)
        {
            mo.ModifedAt += TimeSpan.FromSeconds(i++);
        }
    }
