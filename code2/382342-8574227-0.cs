    var asyncTask = new Task<T>(
    	profiler =>
    	{
    		var currentProfiler = (profiler as MiniProfiler);
    
    		// Create a new profiler just for this step, we're only going to use the SQL timings
    		MiniProfiler newProfiler = null;
    		if (currentProfiler != null)
    		{
    			newProfiler = new MiniProfiler("Async step", currentProfiler.Level);
    		}
    
    		using(var con = /* create new DB connection */)
    		using(var profiledCon = new ProfiledDbConnection(con, newProfiler))
    		{
    		    // ### Do long running SQL stuff ###
    		    profiledCon.Query...
        	}
    		// If we have a profiler and a current step
    		if (currentProfiler != null && currentProfiler.Head != null)
    		{
    			// Add the SQL timings to the step that's active when the SQL completes
    			var currentStep = currentProfiler.Head;
    			foreach (var sqlTiming in newProfiler.GetSqlTimings())
    			{
    				currentStep.AddSqlTiming(sqlTiming);
    			}
    		}
    
    		return result;
    	}, MiniProfiler.Current);
