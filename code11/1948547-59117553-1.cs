		var allTasks = DbContext.Areas
			.SelectMany(a => a.Goals)
			.SelectMany(a => a.Tasks);
		
		var always = allTasks.Where(t => t.ShowAlways);
		
		var next = allTasks
			.OrderBy(tt => tt.Sequence)
			.Take(1);
		
		var result = always
			.Concat(next)
			.Select(t => new
             {
                 // Member assignment
             })
			.ToList();
