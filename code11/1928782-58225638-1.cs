    // This is just to simulate the data source
    IQueryable<RoomContent> query = allPossibleRoomContents.AsQueryable();
    query = query.Where(x => x.ContentDescription = "Sword");
    query = query.Where(x => x.ContentDescription = "Axe");
    // This is where the actual work is done
    return query.ToList();
