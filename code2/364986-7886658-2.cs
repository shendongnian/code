    var employee = new Employee();
    ...
    var department = GetDepartmentFromSomewhere(departmentId);
    using (var context = new YourContext())
    {
        context.Employees.AddObject(employee);
        context.Departments.Attach(department);
        employee.Department = department;
        context.SaveChanges();
    }
