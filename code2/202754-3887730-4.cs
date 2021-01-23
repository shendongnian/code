var query = 
    from pn in context.ProcessNames
    join u in context.Usages.Where(u => u.Datetime > new DateTime(2010, 1, 8) ) 
                                      && u.Datetime &lt; new DateTime(2010, 10, 11),
    on pn.Id equals u.ProcessNameId 
    into g                      
    select new { Name = pn.Name, 
                 Sum = g.Sum(u => u.Amount) };
