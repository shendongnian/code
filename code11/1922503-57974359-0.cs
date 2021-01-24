    IQueryable<Employee> Query = userdb.Employees;
    if (Fn != null) {
        Query = Query.Where(i => i.FirstName.Equals(Fn));
    }
    if (Ln != null) {
        Query = Query.Where(i => i.LastName.Equals(Ln));
    }
    if (desig != null) {
        Query = Query.Where(i => i.Designation.Equals(desig));
    }
    if (country != null) {
        Query = Query.Where(i => i.Country.Equals(country));
    }
    if (gender != null) {
        Query = Query.Where(i => i.Gender.Equals(gender));
    }
    List<Employee> Elist = Query.ToList();
