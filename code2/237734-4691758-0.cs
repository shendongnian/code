        void Main()
    {
    	var list = new List<DateTime>
    	{
    		new DateTime(2010, 10, 11),
    		new DateTime(2009, 3, 4),
    		new DateTime(2010, 5, 8),
    		new DateTime(2010, 8, 10),
    		DateTime.Now,
    		new DateTime(2010, 4, 8)
    	};
    
    var allYearMonthes = list.SelectMany(o => Enumerable.Range(1, 12)
    								 .Select(q => new { o.Year, Month = q }))
    						  .Select(o => o);
    
    var enumerable = allYearMonthes.Except(list.Select(o => new { o.Year, o.Month }));
    
    var dateTimes = enumerable.Select(o => new DateTime(o.Year, o.Month, 1)).Where (o => o.Date > list.Min (l => l.Date) && o.Date < list.Max (l => l.Date));
}
