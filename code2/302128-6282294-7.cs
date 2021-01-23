    public PrintJobByDepartmenReportItem(IEnumerable<IGrouping<string, PrintJob>> g) : base(g)
    {
            this.DepartmentName = g.Key,
            this.NumberOfUsers = g.Select(u => u.GetEnumerator().Current.UserName).Distinct().Count()
    }
