    using (var context = new MyDbContext())
    {
        var thisUser = context.Users.Where(x => x.Id == userId).Single();
        var companiesToSend = context.Companies
            .Where(x => model.CompanyIds.Contains(x.Id))
            .ToArray();
      //....
