    static void Test(DataClasses1DataContext context, DateTime fromDate, DateTime toDate)
    {
        var result = context.Accounts
		            .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= toDate)
		            .GroupBy(x => x.CreatedOn.Date)
		            .Select(x => new {
			           dt = x.Key,
			           count = x.Count()});
    }
