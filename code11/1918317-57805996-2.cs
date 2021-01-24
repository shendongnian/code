    public List<PersonDTO> GetPersons(int pageNumber, int pageSize, List<string> departments, List<string> locations, string filterText = "")
    {
        List<Person> personList = new List<Person>();
        if (!string.IsNullOrEmpty(filterText)) {
            personsList = _dbContext.Persons
                .Where(a => (a.firstName.ToLower().Contains(filterText.ToLower()) || a.lastName.ToLower().Contains(filterText.ToLower()))
                        && departments.Contains(a.department) 
                        && locations.Contains(a.location)).ToList();
        } else {
            personList = _dbContext.Persons.ToList();
        }
            personList = personList.Skip(pageNumber * pageSize).Take(pageSize).ToList();
        return _mapper.Map<List<PersonDTO>>(personsList);
    }
