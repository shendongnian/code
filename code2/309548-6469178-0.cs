    public Person GetBySSN(string ssn) 
    {
        Person p = context.ObjectStateManager
                          .GetObjectStateEntries(~EntityState.Deleted)
                          .Where(e => !e.IsRelationship)
                          .Select(e => e.Entity)
                          .OfType<Person>()
                          .SingleOrDefault(p => p.SSN = ssn);
        if (p == null) 
        {
            p = context.People.SingleOrDefault(p => p.SSN = ssn);
        }
        return p;
    }
