    IQueryable<Experience> query = _context.Experiences;
    
    if (filterExperience.MinPrice.HasValue && filterExperience.MaxPrice.HasValue)
        query = query.Where( x => x.Price >= filterExperience.MinPrice && x.Price <= filterExperience.MaxPrice);
    
    if (filterExperience.Rating.HasValue)
        query = query.Where(x => x.Rating == filterExperience.Rating);
    
    if (filterExperience.CountryId.HasValue)
        query = query.Where( x => x.CountryId == filterExperience.CountryId);
    
    var experienceList = query.ToList();
