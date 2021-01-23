    public static IQueryable<Person> SearchCustomers(
        AdventureWorksEntities entities, string nameQuery, string phoneQuery)
    {
        var wsu = from w in nameQuery.Split()
            where !String.IsNullOrWhiteSpace(w)
            select w;
        var wsp = from w in phoneQuery.Split()
            where !String.IsNullOrWhiteSpace(w)
            select Pack(w);
        return
            entities.People.Where(
                c => wsu.All(w => c.FirstName == w || c.LastName == w)).
                Union(
                    entities.People.Where(
                        c =>
                        wsp.All(
                            w =>
                            c.PersonPhones.Any(p => p.PhoneNumber == w) ||
                            c.EmailAddresses.Any(a => a.EmailAddress1 == w))));
    }
