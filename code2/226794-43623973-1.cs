    using (var v = new EfTestEntities())
    {
        IQueryable<int> employees = from e in v.Employees  select e.Salary;
        employees = employees.Take(2);
    
        foreach (var item in employees)
        {
            Console.WriteLine(item);
        }
    }
