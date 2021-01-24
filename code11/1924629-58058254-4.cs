    [ResponseType(typeof(EmployeeDTO))]
    public EmployeeDTO GetEmployee(int id)
    {
        var employee = from e in dbContext.Employees
                    select new EmployeeDTO()
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Designation = e.Designation
                    };    
        return employee;
    }
