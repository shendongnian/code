    var someData = new List<SomeData>
    {
    	new SomeData {EmpName = "Name 1", CreatedDate = new DateTime(2019, 1, 12)},
    	new SomeData {EmpName = "Name 2", CreatedDate = new DateTime(2019, 2, 2)},
    	new SomeData {EmpName = "Name 3", CreatedDate = new DateTime(2019, 2, 5)},
    	new SomeData {EmpName = "Name 4", CreatedDate = new DateTime(2019, 2, 8)},
    	new SomeData {EmpName = "Name 5", CreatedDate = new DateTime(2019, 3, 2)},
    	new SomeData {EmpName = "Name 6", CreatedDate = new DateTime(2019, 4, 9)},
    };
    
    var defaultMonthNames = new List<MonthNames>
    {
    	new MonthNames {MonthName = "Jan", MonthNum = 1},
    	new MonthNames {MonthName = "Feb", MonthNum = 2},
    	new MonthNames {MonthName = "Mar", MonthNum = 3},
    	new MonthNames {MonthName = "Apr", MonthNum = 4},
    	new MonthNames {MonthName = "May", MonthNum = 5},
    	new MonthNames {MonthName = "Jun", MonthNum = 6},
    	new MonthNames {MonthName = "Jul", MonthNum = 7},
    	new MonthNames {MonthName = "Aug", MonthNum = 8},
    	new MonthNames {MonthName = "Sep", MonthNum = 9},
    	new MonthNames {MonthName = "Oct", MonthNum = 10},
    	new MonthNames {MonthName = "Nov", MonthNum = 11},
    	new MonthNames {MonthName = "Dec", MonthNum = 12},
    };
    
    var crossJoined = from sd in someData
    					from dmn in defaultMonthNames.Where(dmn => dmn.MonthNum <= 4)
    					select new
    					{
    						sd.EmpName,
    						dmn.MonthName,
    						dmn.MonthNum
    					};
    
    var dataMonthCounts = someData
    	.GroupBy(sd => new { sd.EmpName, sd.CreatedDate.Month })
    	.Select(group => new
    	{
    		EmpName = group.Key.EmpName,
    		MonthNum = group.Key.Month,
    		Count = group.Count()
    	});
    
    var results = from cj in crossJoined
    				join dmc in dataMonthCounts
    					on new { cj.EmpName, cj.MonthNum } equals new { dmc.EmpName, dmc.MonthNum } into combined
    				from c in combined.DefaultIfEmpty()
    				select new
    				{
    					cj.EmpName,
    					cj.MonthName,
    					Count = c?.Count ?? 0
    				};
