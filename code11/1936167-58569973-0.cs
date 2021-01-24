    var query = db.From<Employee>()
        .Join<Department>()
        .OrderBy(e => e.Id)
        .Select<Employee, Department>((employee, department) => new { 
            Id = Sql.As(employee.Id, nameof(EmployeeWithDept.Id)), 
            LastName = Sql.As(employee.LastName, nameof(EmployeeWithDept.LastName)), 
            DepartmentName = Sql.As(department.Name, nameof(EmployeeWithDept.DepartmentName))
        }
    );
    var result = db.Select<EmployeeWithDept>(query);
