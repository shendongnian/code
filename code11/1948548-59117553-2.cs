		var allGoals = DbContext.Areas
			.SelectMany(a => a.Goals);
		
		var allTasks = DbContext.Areas
			.SelectMany(a => a.Goals)
			.SelectMany(a => a.Tasks);
		
		var always = allGoals
			.SelectMany(a => a.Tasks)
			.Where(t => t.ShowAlways);
		
		var nextTasks = allGoals
			.SelectMany(g => g.Tasks.OrderBy(tt => tt.Sequence).Take(1));
		
		var result = always
			.Concat(nextTasks)
			.Select(t => new
             {
                 // Member assignment
             })
			.ToList();
