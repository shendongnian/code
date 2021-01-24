	public List<Result> GetGroupedResults(DateTime date)
	{
		return table1
			.Select(x => new {x.code, x.create_Date, x.guid })
			.Where(x => 
				x.code == 0 && 
				x.create_Date > date.AddDays(-2) && 
				x.create_Date < date.AddDays(1))
			.ToList()
			.GroupBy(x => new
			{
				Code = x.code, 
				CreateDateStr = x.create_Date.ToString("MMM dd")
			})
			.OrderBy(g => g.Key.Code)
			.Select(g => new Result
			{
				Code = g.Key.Code, 
				DateStr = g.Key.CreateDateStr, 
				Count = g.Select(g => g.guid).Distinct().Count()
			})
			.ToList();
	}
	
	public class Result
	{
		public int Code { get; set; }
		public string DateStr { get; set; }
		public int Count { get; set; }
	}
