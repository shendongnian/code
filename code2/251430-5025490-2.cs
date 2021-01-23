    List<Star[]> stars = new List<Star[]>
    									   {
    										   new[]
    											   {
    												   new Star {Name = "A", Points = 1}, 
    												   new Star {Name = "B", Points = 2}
    											   },
    										   new[]
    											   {
    												   new Star {Name = "A", Points = 2}, 
    												   new Star {Name = "C", Points = 1}
    											   }
    									   };
    List<Star> plrs =
    		(from p in stars.SelectMany(singleList => singleList)
    		group p by p.Name into g
    		 select new Star { Name = g.Key, Points = g.Average(x => x.Points) })
    		 .OrderBy(x => x.Points)
    		 .ToList();
    
    foreach (Star p in plrs)
    {
    	//OverallPlayers.Add(p.Rank + ". " + p.Name);
    }
