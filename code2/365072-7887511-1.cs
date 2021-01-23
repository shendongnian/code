	var report = from p in trackerReportList.SelectMany(c => c)	
				 group p by new {
				 	ID = p.MilestoneId, 
				 	Name = p.Name,
					Url = p.Url} into g
				 select new {
				 	ID = g.Key.ID,
					Name = g.Key.Name,
					Url = g.Key.Url,
					Counter = g.Sum(c => c.Views)
				};
