    var queryBase = _db.City.OrderBy(x => x.Description);
    
    if (countryTypeId.HasValue)
    {
        queryBase = queryBase.Where(x => x.CountryTypeId == countryTypeId);
    }
    
    if (stateTypeId.HasValue)
    {
        queryBase = queryBase.Where(x => x.StateTypeId == stateTypeId);
    }
    
    return queryBase.ToDTOs(); // or .ToList() for a more universal outcome
