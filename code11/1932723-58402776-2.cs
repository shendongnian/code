    Employees = new List<Employee>
    {
        new Employee() { FirstName = "A", LastName = "Z", DepartmentFK = "D1" },
        new Employee() { FirstName = "B", LastName = "Y", DepartmentFK = "D2" },
        new Employee() { FirstName = "C", LastName = "X", DepartmentFK = "D1" },
        new Employee() { FirstName = "D", LastName = "W", DepartmentFK = "D3" },
        new Employee() { FirstName = "E", LastName = "V", DepartmentFK = "D2" }
    };
    Departments = new List<Department>
    {
        new Department() { ID = "D1", Dept = "Department 01" },
        new Department() { ID = "D2", Dept = "Department 02" },
        new Department() { ID = "D3", Dept = "Department 03" },
        new Department() { ID = "D4", Dept = "Department 04" }
    };
    DisplayEmployees = new List<DisplayEmployee>();
    foreach (var emp in Employees)
    {
        DisplayEmployees.Add(
        new DisplayEmployee()
        {
            FirstName = emp.FirstName,
            LastName = emp.LastName,
            Dept = Departments.Where(x => x.ID == emp.DepartmentFK).FirstOrDefault()
        });
    }
