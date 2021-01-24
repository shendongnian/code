    [ResponseType(typeof(EmployeeResponseObject))]
    public EmployeeResponseObject GetEmployee()
    {
        var employee = from e in dbContext.EmployeeDTO
                    select new EmployeeResponseObject()
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Designation = e.Designation
                    };    
        return employee;
    }
