    IEnumerable<Person> persons = _dbContext.Persons;
    if(!string.IsNullOrEmpty(filterText))
    {
        persons = persons.Where(p => String.Equals(filterText, p.firstName, StringComparison.OrdinalIgnoreCase));
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
