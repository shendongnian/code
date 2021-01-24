    public static async Task<T[]> RunParallel<T>(this IEnumerable<Task<T>> tasks, int maxDegreeOfParallelism)
    {
	    var enumerationLock = new object();
	    var parallelTasks = new List<Task>(maxDegreeOfParallelism);
        var results = new ConcurrentBag<T>();
	    using (var enumerator = tasks.GetEnumerator())
	    {
            // spin up just a few 'agents' to process the tasks
		    await Task.WhenAll(Enumerable
			    .Range(0, maxDegreeOfParallelism)
			    .Select(_ => Task.Run(async () =>
			    {
				    Task<T> task;
				    do
				    {
                        // we need to make sure threads 'de-queue' without interferance
					    lock (enumerationLock)
					    {
                            // pick next element if available
						    if (!enumerator.MoveNext())
						    {
							    return;
						    }
						    task = enumerator.Current;
					    }
                        // wait for task to finish and add aggregate results
					    results.Add(await task);
				    } while (task != null);
			    }))
		    );
            // wait until all 'agents' are finished
		    await Task.WhenAll(parallelTasks);
	    }
        return results.ToArray();
    }
