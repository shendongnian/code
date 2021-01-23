    public IQueryable<Employee> GetEmployeesForRoles(int[] roleIds)
    {
        var employees = _entities.Employees
                                 .Where( x=> x.Roles.Any(r => roleIds.Contains(r.RoleID)))
       return employees;
    }
