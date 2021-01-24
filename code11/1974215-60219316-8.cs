    public IEnumerable<PersonSummaryViewModel> GetPeople(/*criteria*/)
    {
        using (var ctx = new DBContext) 
        {
            var people = ctx.Persons
                .Where( /* based on criteria */ )
                .Select(x => new PersonSummaryViewModel
                {
                   PersonId = x.PersonId,
                   Name = x.Name,
                   TypeName = x.Type.Name,
                   RecentQueries = x.Queries
                       .OrderByDecending(q => q.QueryDate)
                       .Select(q => new QuerySummaryViewModel
                       {
                          QueryId = q.QueryId,
                          Name = q.Name,
                          LocationName = q.Location.Name
                          // ... etc.
                       }).Take(2).ToList()
                }).ToList();
            //...
            return people;
        }
    }
