    var list = new List<MemObject>
    {
        new MemObject
        {Serial = 1, ErrorCode = "ABC", ModifedAt = new DateTime(2011, 12, 15, 10, 10, 30)},
        new MemObject
        {Serial = 1, ErrorCode = "ABD", ModifedAt = new DateTime(2011, 12, 15, 10, 10, 30)},
        new MemObject
        {Serial = 1, ErrorCode = "ABC", ModifedAt = new DateTime(2011, 12, 15, 10, 10, 30)},
        new MemObject
        {Serial = 1, ErrorCode = "ABC", ModifedAt = new DateTime(2011, 12, 15, 10, 10, 30)},
    };
    var query = list.GroupBy(mo => new { mo.Serial, mo.ErrorCode });
    foreach (var group in query)
    {
        int i = 0;
        foreach (var mo in group)
        {
            mo.ModifedAt += TimeSpan.FromSeconds(i++);
        }
    }
