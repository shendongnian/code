    using (var transaction = _dbContext.Database.BeginTransaction())
    {
        var thisUser = _dbContext.Users.Where(x => x.Id == model.UserId).Single();
        var companiesToSend = _dbContext
            .Companies
            .Where(x => model.CompanyIds.Contains(x.Id))
            .ToArray();
      //....
