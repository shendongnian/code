    // explicit result class for the first task
    class ProfiledResult<T>
    {
    	internal List<SqlTiming> SqlTimings { get; set; }
    	internal T Result { get; set; }
    }
    Timing currentStep = null;
    if (MiniProfiler.Current != null &&
    	MiniProfiler.Current.Head != null)
    {
    	currentStep = MiniProfiler.Current.Head;
    }
    else
    {
    	// Kick off an unprofiled task
    	return Task<T>.Factory.StartNew(
    	() =>
    	{
            return // ### Do long running SQL stuff ###
    	});
    }
    
    // Create a task that has its own profiler
    var asyncTask = new Task<ProfiledResult<T>>(
    	() =>
    	{
    		// Create a new profiler just for this step, we're only going to use the SQL timings
    		var newProfiler = new MiniProfiler("Async step");
    		var result = new ProfiledResult<T>();
    
    		result.Result = // ### Do long running SQL stuff ###
    
    		// Get the SQL timing results
    		result.SqlTimings = newProfiler.GetSqlTimings();
    		return result;
    	});
    
    // When the task finishes continue on the main thread to add the SQL timings
    var asyncWaiter = asyncTask.ContinueWith<T>(
    	t =>
    	{
    		// Get the wrapped result and add the timings from SQL to the current step
    		var completedResult = t.Result;
    		foreach (var sqlTiming in completedResult.SqlTimings)
    		{
    			currentStep.AddSqlTiming(sqlTiming);
    		}
    
    		return completedResult.Result;
    	}, TaskContinuationOptions.ExecuteSynchronously);
    
    
    asyncTask.Start();
    return asyncWaiter;
