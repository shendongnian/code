    List<Employee> employees = new List<Employee>();
    for(int i=0;i<2500000;i++)
    {
        employees.Add(new Employee
        {
            Id = Guid.NewGuid().ToString(),
            Identifier = Guid.NewGuid().ToString(),
            Type = i.ToString(),
            StartDate = DateTime.MinValue,
            EndDate = DateTime.Now
        });
    }
    var newEmployees = employees
        .Where(x => x.Identifier != null)
        .OrderBy(x => x.Identifier)
        .ToArray();
