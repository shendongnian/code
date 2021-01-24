    using (var ctx = new DBContext) 
    {
        var persons = ctx.Persons
            .Select(x => new PersonViewModel
            {
               PersonId = x.PersonId,
               Name = x.Name,
               TypeName = x.Type.Name,
               RecentQueries = x.Queries
                   .OrderByDecending(q => q.QueryDate)
                   .Select(q => new QueryViewModel
                   {
                      QueryId = q.QueryId,
                      Name = q.Name,
                      LocationName = q.Location.Name
                      // ... etc.
                   }).Take(2).ToList()
              }
        }.ToList();
        //...
    }
