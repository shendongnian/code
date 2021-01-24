    var providerIds = respondent.Providers.Select(x => x.UPI).ToList();
    var providers = db.Users.Where(x => providerIds.Contains(x.UPI)).ToList();
    var requester = db.Users.Single(s => s.UserId == respondent.Requester.UserId);
    requester.IsPublic = false;
    foreach(var providerId in providerIds)
    {
       if (!db.Respondents.Any(x => x.Requester.UserId == requester.UserId)) 
       {
           var provider = providers.Single(x => x.UPI == providerId);
           provider.IsPublic = true;
           db.Respondents.Add(new Respondent() { Requester = requester, Provider = provider, Role = provider.Role });
       }
    }
    db.SaveChanges();
