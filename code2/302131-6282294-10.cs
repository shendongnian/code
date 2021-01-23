    public PrintJobByDepartmentReportItem(IEnumerable<IGrouping<string, PrintJob>> g) : base(g)
    {
        this.DepartmentName = g.First().Key;
        this.NumberOfUsers = g.Select(i => i.GetEnumerator().Current.UserName).Distinct().Count();
    }
