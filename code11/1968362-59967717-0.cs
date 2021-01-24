     var query = _dbContext.Institution.Include(a => a.Services);
     if(something)
     {
        query = query.Where(a => a.Id == institutionId);
     }
     ...
     var results = query.ToList();  // <-- This 'executes' the query
     etc
