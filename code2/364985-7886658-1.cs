    using (var context = new YourContext())
    {
        var employee = new Employee();
        ...
        context.Employees.AddObject(employee);
        
        employee.Department = context.Departments.Single(d => d.Id == departmentId);
        context.SaveChanges();
    }
