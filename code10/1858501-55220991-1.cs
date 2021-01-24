    public static void  InsertEmployee(Employee employee )
    {    
        EmployeeDBContext empDBContext = new EmployeeDBContext();
        empDBContext.Employee.Add(employee);
        empDBContext.SaveChanges();
    }
