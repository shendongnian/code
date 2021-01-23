    IQueryable<YourType> query = /* some basic query; maybe db.TheTable */
    if(!string.IsNullOrEmpty(firstName))
        query = query.Where(row => row.FirstName == firstName);
    if(!string.IsNullOrEmpty(lastName))
        query = query.Where(row => row.LastName == lastName);
    if(!string.IsNullOrEmpty(fatherName))
        query = query.Where(row => row.FatherName == fatherName);
    // etc
    var matches = query.Take(50).ToList();
