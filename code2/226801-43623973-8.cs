    using (var efContext = new EfTestEntities())
    {
        IEnumerable<int> employees = from e in efContext.Employees  select e.Salary;
        employees = employees.Take(2);
    
        foreach (var item in employees)
        {
            Console.WriteLine(item);
        }
    }
