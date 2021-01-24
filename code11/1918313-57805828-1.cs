    IEnumerable<Person> persons = _dbContext.Persons;
    if(!string.IsNullOrEmpty(filterText))
    {
        string lowerFilterText = filterText.ToLower();
        persons = persons
           .Where(p => p.firstName.ToLower().Contains(lowerFilterText) || a.lastName.ToLower().Contains(lowerFilterText));
    }
    if(departments.Any())
    {
        persons = persons.Where(p => departments.Contains(p.department));
    }
    if(locations.Any())
    {
        persons = persons.Where(p => locations.Contains(p.location));
    }
    List<Person> personList = persons.Skip(pageNumber * pageSize).Take(pageSize).ToList();
