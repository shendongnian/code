    using (var dbContext = new MyDbContext())
    {
        IQueryable<Institution> filteredInstitutions = (filter == null) ?
            dbContext.Institutions :
            dbContext.Institutions.Where(filter);
        return filteredInstitutions.Select(institution => new Institution
        {
            // Select only the Institution properties that you actually plan to use:
            Id = institution.Id,
            Name = institution.Name,
            City = new City
            {
                Id = institution.City.Id,
                Name = institution.City.Name,
                ...
            }
            // not needed: you already know the value:
            // CityId = institution.City.Id,
    });
