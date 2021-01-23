    return db.tblGPlusOneClicks
        .Where(c => c.UserID == UserID)
        .GroupBy(c=>c.URLID)
        .Select(g => new {
              URLID = g.Key,
              VoteBalance = g.Aggregate(0, (a,i) => a+(i.IsOn?1:-1))
        })
        .Sum(u => u.VoteBalance);
