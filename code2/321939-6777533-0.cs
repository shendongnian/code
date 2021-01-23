    IQueryable<Person> people = _db.Person
                                   .Where(res => res.Departments.ID == deptId);
    if (deptType != null)
    {
        people = people.Where(res => res.Departments.Type == deptType);
    }
    // Potentially add projections etc.
