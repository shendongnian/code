    public static void  InsertEmployee(Employee employee )
    {    
        EmployeeDBContext empDBContext = new EmployeeDBContext();
        empDBContext.SaveChanges();
    }
