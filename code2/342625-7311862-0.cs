    var result = dbContext.Users
        .Select(u => new 
                       {
                           UserID = u.Id, 
                           NumberOfMessages = u.Messages.Count()
                       })
        .ToList();
