    IQueryable<Route> query = Routes
    
    if (code != null)
    {
      query = query.Where(x => x.Code == code)
    }
    if (searchPattern != null)
    {
      query = query.Where(x => x.Locations.Any(loc => loc.Name.Contains(searchPattern)))
    }
    if (prefix != null)
    {
      query = query.Where(x => x.Locations.First().Name.StartsWith(prefix));
    }
