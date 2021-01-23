    public IQueryable<Employee> GetEmployeesForRoles(int[] roleIds)
    {
        var employees = _entities.Roles
                                 .Where( r => roleIds.Contains(r.RoleID))
                                 .SelectMany( x=> x.Employees)
                                 .Distinct()
       return employees;
    }
