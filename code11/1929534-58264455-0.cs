    var result = table2.Where(x=>x.Date!=null)
    				   .GroupBy(x=> new {x.Name, x.Graduation})
    				   .SelectMany(x=> x.OrderByDescending(c=>c.Version).Take(1))
    				   .Join(table1,t2=>t2.Table1ID,t1=>t1.Table1ID,(t2,t1)=>t1)
    				   .ToList();
    result.AddRange(table1.Where(x=> result.Any(c=>c.Name.Equals(x.Name) 
                                                && c.Graduation.Equals(x.Graduation) 
                                                && c.Version < x.Version)));	
