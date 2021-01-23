    [PrincipalPermission(SecurityAction.Demand, Role="DepartmentManager")]
    public IEnumerable<Employee> GetManagedEmployees()
    {
      // build base query
      var query = from e in context.Employees
                  select e;
    
      // add condition
      query = AddDepartmentPermissions(query);
      return query.AsEnumerable();
    }
