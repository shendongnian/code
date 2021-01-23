    public IEnumerable<Person> getPeople(string searchField, string searchTerm) {
            PropertyInfo getter=typeof(Person).GetProperty(searchField);
            if(getter==null) {
                throw new ArgumentOutOfRangeException("searchField");
            }
            return _repo.GetAll().Where(x => getter.GetValue(x, null).ToString()==searchTerm);
    }
