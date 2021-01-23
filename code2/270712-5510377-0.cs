    public IEnumerable<Person> SearchPersons(IHasPersonsTable context, string searchFilter)
    {
        return IHasSomePersonsTable.Persons
                     .Where(p => p.SearchableThing.Contains(searchFilter));
    }
