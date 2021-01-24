    private IDBModelFactory factory;
    public EmployeeRepository(IDBModelFactory factory)
    {
        this.factory = factory
    }
    public async Task<bool> Add(Employee employee)
    {
        using (var contextBD = factory.Create())
        {
            contextBD.Employee_Table.Add(new Employee_Table()
            {
                LLP_Id = employee.id,
                Name = employee.name,
            });
            await contextBD.SaveChangesAsync();
        }
        return true;
    }
