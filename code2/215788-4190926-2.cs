    // Construct base query
    var query = (from p in db.tblProCons
    			 where p.IdPrimaryCity == idPrimaryCity
    			 group p by new { p.IdPrimaryCity, p.IsPro, p.Description } into g
    			 select new { ProCon = g.Key, NumberOfAgrees = g.Count() });
    
    // Split queries based on pro/con, and apply TOP(3)
    var pros = query.Where(x => x.ProCon.IsPro).Take(3);
    var cons = query.Where(x => !x.ProCon.IsPro).Take(3);
    
    result = pros
    	.Union(cons) // Union pro/cons
    	.OrderByDescending(x => x.ProCon.IsPro) // Order #1 - Pro/Con
    	.ThenByDescending(x => x.NumberOfAgrees) // Order #2 - Number of Agree's
    	.Select(x => new ProCon // project into cut-down POCO
    			{
    				Description = x.ProCon.Description,
    				IsPro = x.ProCon.IsPro
    			}).ToList();
