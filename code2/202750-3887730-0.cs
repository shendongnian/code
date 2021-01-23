var query = context.ProcessNames
    .GroupJoin(context.Usages.Where(u => u.Datetime > new DateTime(2010, 1, 8) ) 
                                      && u.Datetime < new DateTime(2010, 10, 11),
               pn  => pn.Id,
               u => u.ProcessNameId, 
               (pn, usages) => new { Name = p.Name, 
                                     Sum = usages.Sum(u => u.Quantity) });
