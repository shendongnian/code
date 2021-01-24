        context.Orders
               .Select(x => new
               { 
                   x.Number,
                   Owner = x.Owner.Name, 
                   Status = x.Status.Name
               }
    ...again generates SQL with two joins and returns anonymous type objects, no `Owner`, no `Status`.
        context.Orders
               .Include(o => o.Owner)
               .Select(x => new
               { 
                   x.Number,
                   Owner = x.Owner.Name, 
                   Status = x.Status.Name
               }
