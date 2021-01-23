    public override IQueryable<ListData> listQuery()
    {
        var dc = new NorthwindDataContext();
        var allrows = from emp in dc.Employees
                    select new EmployeeData()
                    {
                        EmployeeId = emp.EmployeeID,
                        ReportsToId = emp.ReportsTo, ...
                    } as ListData;
        return allrows.OfType<ListData>();
    }
