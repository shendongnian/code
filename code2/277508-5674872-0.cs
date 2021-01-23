    public IEnumerable<string> FilterEmployees (IEnumerable<Employee> source, bool restrictDepartment)
    {
        var query = source.Where (e => e.Field<string>("EmployeeName") == "Jhom");
    
        if (restrictDepartment) // btw, there's no need for "== true"
            query = query.Where (e => e.Field<string>("EmployeeDepartment") == "IT");
       
        return query.Select (e => e.Field<string>("EmployeeID"));
    }
