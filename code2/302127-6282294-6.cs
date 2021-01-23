	public PrintJobReportItem(IEnumerable<IGrouping<string, PrintJob>> g)
	{
		IEnumerable<PrintJob> theGroup = g.GetEnumerator().Current;
		this.TotalPagesPrinted = theGroup.Sum(p => p.PagesPrinted);
		this.AveragePagesPrinted = theGroup.Average(p => p.PagesPrinted);
		this.PercentOfSinglePagePrintJobs = theGroup.Count(p => p.PagesPrinted == 1) / theGroup.Count(p => p.PagesPrinted);
	}
