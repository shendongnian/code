    public PrintJobReportItem()
    {
    }
    public PrintJobReportItem(IEnumerable<IGrouping<string, PrintJob>> g)
    {
        this.TotalPagesPrinted = g.Sum(i => i.GetEnumerator().Current.PagesPrinted);
        this.AveragePagesPrinted = g.Average(i => i.GetEnumerator().Current.PagesPrinted);
        this.PercentOfSinglePagePrintJobs = g.Count(i => i.GetEnumerator().Current.PagesPrinted == 1) * 100 / g.Count(i => i.GetEnumerator().Current.PagesPrinted > 1);
    }
