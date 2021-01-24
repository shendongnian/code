    var asset = dbContext.Set<Asset>()
        .Include(....)
        .Where(x => x.AssetCurrentStatus.AssetLocation == null 
                || (x.AssetCurrentStatus.Room.Floor.IsActive 
                 && x.AssetCurrentStatus.Room.Floor.Building.IsActive 
                 && x.AssetCurrentStatus.Room.IsActive))
        .ToList();
