    //This work against in memory list (TESTED)
    var result = dbcontext.Students.OrderByDescending(s => s.Id)
                          .GroupBy(s => s.Guid)
                          .Take(2)
                          .SelectMany(s=>s.ToList());
    //IF EF doesn't able to convert the query you can try this.
    var inMemoryGrouped = dbcontext.Students.OrderByDescending(s => s.Id)
                          .GroupBy(s => s.Guid)
                          .Take(2)
                          .ToList();
    //Flatten the items using select many 
    var final = inMemoryGrouped.SelectMany(y=>y.ToList());
    
