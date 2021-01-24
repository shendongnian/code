    var query = _context.Students.Where(x => x.FacultetId == Facultet);
    
    // filter by profession if there is some value
    if (!string.IsNullOrempty(model.Profession))
    {
        query = query.Where(x => x.Profession.Contains(model.Profession));
    }
    // continue with the rest of the filters...
    // and only then execute the query
    var students = query.ToList();
