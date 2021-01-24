    [HttpGet]
    public IEnumerable<Person> Get()
            {
                return SQLiteDataAccess.GetPeople();
            }
