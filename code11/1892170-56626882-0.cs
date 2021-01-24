    public void ParallelForProgressExample(IProgress<int> progress = null)
    {
	    int percent = 0;
	    ...
	    var result = Parallel.For(fromInclusive, toExclusive, (i, state) => 
	    {
		    // do your work
    		lock (lockObject)
		    {
			    // caluclate percentage
			    // ...
			
			    // update progress
			    progress?.Report(percent);
		    }
	    });
    }
