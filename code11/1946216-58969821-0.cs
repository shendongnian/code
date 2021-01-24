    IQueryable<Experience> query = _context.Experiences;
    
    if (filterExperience.MinPrice.HasValue && filterExperience.MaxPrice.HasValue)
        query = query.Where(x.Price >= filterExperience.MinPrice && x.Price <= filterExperience.MaxPrice);
    
    if (filterExperience.Rating.HasValue)
        query = query.Where(x.Rating == filterExperience.Rating);
    
    if (filterExperience.CountryId.HasValue)
        query = query.Where(x.CountryId == filterExperience.CountryId);
    
    List<Experience> experienceList = query.ToList();
