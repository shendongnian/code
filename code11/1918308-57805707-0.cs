    public List<PersonDTO> GetPersons(int pageNumber, int pageSize, List<string> departments, List<string> locations, string filterText)
    {
        if (filterText == null)
        {
            filterText = "";
        }
        List<Person> personsList = _dbContext.Persons
            .Where(a => (a.firstName.ToLower().Contains(filterText.ToLower())
                          || a.lastName.ToLower().Contains(filterText.ToLower()))
                        && (!departments.Any() || departments.Contains(a.department))
                        && (!locations.Any() || locations.Contains(a.location)))
            .Skip(pageNumber * pageSize).Take(pageSize).ToList();
        return _mapper.Map<List<PersonDTO>>(personsList);
    }
