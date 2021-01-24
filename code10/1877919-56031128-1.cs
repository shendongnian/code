    var providerIds = respondent.Providers.Select(x => x.UserId).ToList();
    var providers = db.Users.Where(x => providerIds.Contains(x.UserId)).ToList();
    var requester = db.Users.Single(s => s.UserId == respondent.Requester.UserId);
    requester.IsPublic = false;
    foreach(var providerId in providerIds)
    {
       if (!db.Respondents.Any(x => x.Requester.UserId == requester.UserId)) 
       {
           var provider = providers.Single(x => x.ProviderId == providerId);
           provider.IsPublic = true;
           db.Respondents.Add(new Respondent() { Requester = requester, Provider = provider, Role = provider.Role });
       }
    }
    db.SaveChanges();
