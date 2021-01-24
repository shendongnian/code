    // Store a list of parcel states
    var parcelStates = new List<ParcelState>();
    
    // Read top 100 parcels from the database
    var parcels = dbContext.Parcels
                           .OrderBy(p => p.Id)
                           .Take(100);
    
    // For each parcel, use SQL to lookup the 2 most recent parcel states
    foreach (var p in parcels)
    {
        var ps = dbContext.ParcelStates
                                    .Where(ps => ps.ParcelId == p.Id)
                                    .OrderByDescending(ps => ps.Id)
                                    .Take(2);
        parcelStates.AddRange(ps);
    }
    
    // Now we have all parcel states for those parcels
    Console.WriteLine($"Found {parcelStates.Count} parcel states for {parcels.Count} parcels");
