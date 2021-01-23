    public List<Person> getPeopleFromClassLowerThanLimit(int classId, int height)
    {
        Database db = new Database();
        return db.Persons.Where(p => isLowerThan(p, classId, height)).ToList();
    }
    private bool isLowerThan(Person person, int classId, int height)
    {
    
    }
