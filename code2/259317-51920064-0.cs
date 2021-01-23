    using (Entities entities = new Entities())
    {
          int employeeId = entities.Employee.Add(new Employee
                            {
                                EmployeeName = employeeComplexModel.EmployeeName,
                                EmployeeCreatedDate = DateTime.Now,
                                EmployeeUpdatedDate = DateTime.Now,
                                EmployeeStatus = true
                            }).EmployeeId;
    
          //...use id for other work
    }
