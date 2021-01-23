    list.GroupBy(o => o.MatchId)
        .Select(g => new PairedObject
                         {
                             IsApproved = g.First(o => o.IsApproved),
                             NotApproved = g.First(o => !o.IsApproved)
                         });
      
