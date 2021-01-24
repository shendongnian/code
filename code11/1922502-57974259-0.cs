    IQueryable<Employee> query = userdb.Employees;
    
    if(!string.IsNullOrEmpty(Fn))
    {
        query = query.Where(e => e.FirstName == Fn);
    }
    if(!string.IsNullOrEmpty(Ln))
    {
        query = query.Where(e => e.LastName == Ln);
    }
    // etc. etc.
    List<Employee> Elist = query.ToList();
