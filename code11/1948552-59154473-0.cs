c#
		var tasks =   ( from a in DbContext.Areas
					   	from g in a.Goals
						from t in g.Tasks 
							join oneTask in (from  t in DbContext.Tasks
							group t by t.Id into gt
							select new {
								  Id = gt.Key,
								  Sequence = gt.Min(t => t.Sequence)
							  }) on  new { t.Id, t.Sequence } equals  new { oneTask.Id,oneTask.Sequence }
							select new {Area = a, Goal = g, Task = t})
						.Union(			
						from a in DbContext.Areas
					   	from g in a.Goals
						from t in g.Tasks 
							where t.ShowAlways 
							select new {Area = a, Goal = g, Task = t});
			
