	var first = from a in MarksAList
				from b in MarksBList.Where(x => x.Id == a.Id).DefaultIfEmpty()
				select new Marks
				{
					Id = ((int?)a.Id) ?? b.Id,
					Name = a.Name ?? b.Name,
					Mark1 = a?.Mark1 ?? 0,
					Mark2 = a?.Mark2 ?? 0,
					Mark3 = a?.Mark3 ?? 0,
					Mark4 = b?.Mark4 ?? 0,
					Mark5 = b?.Mark5 ?? 0,
					Mark6 = b?.Mark6 ?? 0
				};
	var second = from b in MarksBList
				 from a in MarksAList.Where(x => x.Id == b.Id).DefaultIfEmpty()
				 select new Marks
				 {
					 Id = ((int?)b.Id) ?? a.Id,
					 Name = b.Name ?? a.Name,
					 Mark1 = a?.Mark1 ?? 0,
					 Mark2 = a?.Mark2 ?? 0,
					 Mark3 = a?.Mark3 ?? 0,
					 Mark4 = b?.Mark4 ?? 0,
					 Mark5 = b?.Mark5 ?? 0,
					 Mark6 = b?.Mark6 ?? 0
				 };	
    // it will act same as distinct and remove the duplicated rows
	var final = first.Union(second).GroupBy(x => x.Id).Select(x => x.First());
