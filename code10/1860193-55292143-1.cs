    var followUps =  ctx.FollowUps
        .Where(f => f.DestEntityId == user.Id 
               && f.DestEntityType == (int)ContactEntityTypeEnum.User)
        .OrderByDescending(x => x.AddDate)
        .Select(x => new
        { 
            UserFirstname = user.Firstname,
            AddDate = x.AddDate,
            FollowupDate = x.NextFollowUpDate
        }).ToList();
