Areas.SelectMany(x=>x.Goals)
    .Select(g=>new {
	    NextTaskId=g.Tasks.OrderBy(t=>t.Sequence).FirstOrDefault()?.Id,
	    Tasks=g.Tasks.Where(t=>t.ShowAlways)
      })
    .SelectMany(a=>a.Tasks,(a,task)=>new {
	        NextTaskId = a.NextTaskId,
            Task = task
      });
