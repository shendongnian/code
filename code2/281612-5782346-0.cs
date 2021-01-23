    var query = arrangements
    	.GroupBy(a => a.Aspect.Name)
    	.Select(g => 
    	new 
    	{ 
    		Steps = ga.SelectMany(a => a.Steps)
    				  .GroupBy(s => s.Rank)
    				  .Select(gs => gs.Last()),
    		AspectName = ga.Key,               // whether you only want aspect name
            AspectObject = ga.First().Aspect   // ...or entire aspect object
    	});
