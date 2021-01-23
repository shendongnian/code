	public PrintJobReportItem(IEnumerable<PrintJob> g)
	{
		this.TotalPagesPrinted = g.Sum(p => p.PagesPrinted);
		this.AveragePagesPrinted = g.Average(p => p.PagesPrinted);
		this.PercentOfSinglePagePrintJobs = g.Count(p => p.PagesPrinted == 1) / g.Count(p => p.PagesPrinted);
	}
