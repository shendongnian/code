    var query = _db.Parameter
                .OrderBy(x => x.EndDate)
                .ToList();
    var parameter = query.FirstOrDefault(x => givenDate < x.EndDate);
    if ( parameter == null )
      parameter = query.FirstOrDefault(x => x.EndDate == null);
    if ( parameter == null )
      ...
    else
      ...
