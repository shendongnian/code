      var result = reasons.Where(x => x.PrimaryId == null)
                .Select(x =>
                {
                    x.SecReason = reasons.Where(r => x.PrimaryId == x.Id)
                                         .Select(r => new SecondryReason()
                                         {
                                             Id = r.Id,
                                             ReasonName = x.ReasonName,
                                             PrimaryReasonId = x.Id
                                         })
                                         .ToList();
                    return x;
                });
