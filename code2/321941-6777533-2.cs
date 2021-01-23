    Expression<Func<Person, bool> predicate = res => res.Departments.ID == deptId;
    if (deptType != null)
    {
        predicate = predicate.Or(res => res.Departments.Type == deptType);
    }
    IQueryable<Person> people = _db.Person.Where(predicate);
