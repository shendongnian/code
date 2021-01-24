	var list = new []
	{
		new Data{Month=5,Total=100,Year=2019,Id=1},
		new Data{Month=7,Total=100,Year=2019,Id=1},
		new Data{Month=5,Total=100,Year=2019,Id=2},
		new Data{Month=9,Total=100,Year=2019,Id=2},
		new Data{Month=2,Total=100,Year=2020,Id=2}
	};
	
	var result = list.GroupBy(x=>x.Id)
						.Select(x=>
						{
							var minDate = x.ToList().Select(c=> new DateTime(c.Year,c.Month,1)).Min();
							var maxDate = x.ToList().Select(c=> new DateTime(c.Year,c.Month,1)).Max();
							
							return x.ToList().Union(Enumerable.Range(0, Int32.MaxValue)
                     						 .Select(e => minDate.AddMonths(e))
                     						 .TakeWhile(e => e <= maxDate)
                     						 .Select(e => new Data{Month=e.Month, Total=0,Year=e.Year,Id=x.Key}))
											 .OrderBy(v=> new DateTime(v.Year,v.Month,1))
											 .GroupBy(c=>new {c.Month,c.Year})
											 .Select(g=>g.First());
						}).SelectMany(v=>v);
