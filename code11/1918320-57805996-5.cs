    public List<PersonDTO> GetPersons(int pageNumber, int pageSize, List<string> departments, List<string> locations, string filterText = "")
        {
            IQueryable<List<Person>> personQuery = _dbContext.Persons.AsQueryable();
            if (!string.IsNullOrEmpty(filterText))
            {
                personQuery = personQuery
                    .Where(a => (a.firstName.ToLower().Contains(filterText.ToLower()) || a.lastName.ToLower().Contains(filterText.ToLower()))
                            && departments.Contains(a.department)
                            && locations.Contains(a.location));
            }
            personQuery = personQuery.Skip(pageNumber * pageSize).Take(pageSize);
            return _mapper.Map<List<PersonDTO>>(personQuery.ToList());
        }
