	 var overviewList = tmpList
	   .Select(i => new { ProjectId = i.ProjectId, 
						  Ts = TimeSpan.Parse(i.ProjectTime) })
	  .GroupBy(i => i.ProjectId)
	  .Select(g => new { ProjectId = g.Key,
						 Hour = g.Sum(i => i.Ts) })
	  .ToList();
