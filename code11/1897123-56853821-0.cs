C#
Festival fest = new Festival();
	List<Performance> allPerformances = new List<Performance>();
	// Above I've added my test performances (1, 'A'), (1, 'B'), (2, 'A'), (2, 'C') etc.
	allPerformances.Add(new Performance(){day = DateTime.Parse("1/1/2019"), stage = "A"});
	allPerformances.Add(new Performance(){day = DateTime.Parse("1/1/2019"), stage = "B"});
	allPerformances.Add(new Performance(){day = DateTime.Parse("1/1/2019"), stage = "C"});
	allPerformances.Add(new Performance(){day = DateTime.Parse("1/2/2019"), stage = "A"});
	allPerformances.Add(new Performance(){day = DateTime.Parse("1/2/2019"), stage = "B"});
	allPerformances.Add(new Performance(){day = DateTime.Parse("1/2/2019"), stage = "C"});
	
	allPerformances.Add(new Performance(){day = DateTime.Parse("1/3/2019"), stage = "A"});
	allPerformances.Add(new Performance(){day = DateTime.Parse("1/3/2019"), stage = "C"});
	
	allPerformances.Add(new Performance(){day = DateTime.Parse("1/4/2019"), stage = "A"});
	allPerformances.Add(new Performance(){day = DateTime.Parse("1/4/2019"), stage = "C"});
		
	fest.performances = allPerformances.OrderBy(o=>o.day).ToList();
	
	//get list of ALL fest days
	var listOfDays = GetDateRange( fest.performances.Min(s=>(s.day)),fest.performances.Max(s=>(s.day)));
	List<string> result = new List<string>();
	allPerformances.GroupBy(g => new { g.stage })
	.ToList().ForEach(fe => { 
		if(listOfDays.Count() == fe.Select(s=>s.day).Distinct().Count())
			result.Add(fe.Select(s=>s.stage).FirstOrDefault());
	});
	
	Console.Write(result);
and classes and function
C#
public class Festival
{
	public List<Performance> performances { get; set;}
	public Festival(){performances = new List<Performance>();}
}
public class Performance
{
	public DateTime day { get; set; }
	public string stage { get; set;}
	public Performance(){}
}
public static IEnumerable<DateTime> GetDateRange(DateTime startDate, DateTime endDate)
{
	if (endDate < startDate)
		throw new ArgumentException("endDate must be greater than or equal to startDate");
	while (startDate <= endDate)
	{
		yield return startDate;
		startDate = startDate.AddDays(1);
	}
}
as result you should get A and C.
i hope i understood you correctly...
