    var mickeyMouseImageId = myDbContext.Images
                                     .Where(image => image.Name == "Mickey Mouse)
                                     .Select(image => image.Id)
                                     .FirstOrDefault();
    // TODO: check that the image really exists, so result not zero
    // Add a new UserExtendedInfo that uses mickey Mouse as Avatar:
    var addedUserExtendedInfo = myDbContext.UserExtendedInfos.Add(new UserExtendedInfo()
    {
         // fill the foreign key:
         AvatarId = mickeyMouseId,
         ... // other properties; don't fill the primary Key in Id
    });
