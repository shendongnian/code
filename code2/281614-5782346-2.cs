    var query = arrangements
    	.GroupBy(a => a.Aspect.Name)
    	.Select(g => 
    	new Arrangement
    	{ 
    		Steps = ga.SelectMany(a => a.Steps)
    				  .GroupBy(s => s.Rank)
    				  .Select(gs => gs.Last()),
            Aspect = ga.First().Aspect
    	});
