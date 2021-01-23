    var employee = new Employee();
    employee.Department = GetDepartmentFromSomewhere(departmentId);
    ...
   
    using (var context = new YourContext())
    {
        context.Employees.AddObject(employee);
        context.ObjectStateManager.ChangeObjectState(employee.Department, 
                                                     EntityState.Unchanged);
        context.SaveChanges();
    }
