    public static Person[] GetAllPersons(
        IEntityFilter<Person> filter)
    {
        using (var db = ContextFactory.CreateContext())
        {
            IQueryable<Person> filteredList =
                filter.Filter(db.Persons);
            return filteredList.ToArray();
        }
    }
