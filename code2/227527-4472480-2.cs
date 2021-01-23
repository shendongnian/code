    public static IQueryable GetActiveEmployees_Grid(string Period)
    {
        DataContext Data = new DataContext();
        var Employees = (from c in DataSystem_Records
                         where c.Period == Period
                         orderby c.DataSystem_Employees.LName
                         select c).GroupBy(g=>g.DataSystem_Employees.AccID).Select(x=>x.FirstOrDefault());
        return Employees;
    }
