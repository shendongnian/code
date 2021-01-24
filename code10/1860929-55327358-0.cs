    var model = new AggregationViewModel();
    //----------------------------------------
    var tasks = new List<Task<int>>();
    //Add CountA
    tasks.Add(_repository.GetCountAsync<filter>(Predicate));
    //Add CountB
    tasks.Add(_repository.GetCountAsync<Flight>(predicate.And(x => x.Status == "refused")));
    
    //----------------------------------------
    // Create a task with "allTasks" name to wait to complete all tasks
    Task allTasks = Task.WhenAll(tasks);
    try {
    	// Wait to compelete "allTask"
    	 allTasks.Wait();
    }
    catch(AggregateException) 
    {}
    
    //----------------------------------------
    //Working on the results
    
    if (allTasks.Status == TaskStatus.RanToCompletion) {
       model.CountA=t.Result[0]
       model.CountB=t.Result[1]
    }
    // Display information on faulted tasks.
    else {
    	foreach (var t in tasks) {
    		Console.WriteLine("Task {0}: {1}", t.Id, t.Status);
    	 }
    }
