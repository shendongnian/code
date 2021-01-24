	 var overviewList = tmpList
	   .Select(i => new { ProjectId = i.ProjectId, 
						  Hour = int.Parse(i.ProjectTime.Substring(0, i.IndexOf(':'))), 
						  Minute = int.Parse(i.ProjectTime.Substring(i.IndexOf(':') + 1)) })
	  .GroupBy(i => i.ProjectId)
	  .Select(g => new { ProjectId = g.Key,
						 Hour = g.Sum(i => i.Hour),
						 Minute = g.Sum(i => i.Minute) })
	  .ToList();
