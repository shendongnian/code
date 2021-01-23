    public static IQueryable GetActiveEmployees_Grid(string Period)
    {
        DataContext Data = new DataContext();
        var Employees = (from c in DataSystem_Records
                         where c.Period == Period
                         orderby c.DataSystem_Employees.LName
                         select new { FirstName = c.DataSystem_Employees.FName, LastName = c.DataSystem_Employees.LName, ID = c.DataSystem_Employees.ID }).Distinct();
        return Employees;
    }
