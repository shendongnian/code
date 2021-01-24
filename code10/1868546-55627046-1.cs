    var result = dbContext.Centers
        .Where(center => center.CountryCode == "UK")
        .Select(center => new
        {
            // select only the properties that you plan to use
            Id = center.Id,
            Name = center.Name,
            ...
            ObsoleteFacilities = center.Facilities
              .Where(facility => facility.Obsolete)
              .Select(facility => new
              {
                  // again, only the properties you plan to use
                  Id = facility.Id,
                  ...
              })
              .ToList(),
         });
