	class TransitionRunner
	{
		readonly List<IDayTransitionAction> list = new List<IDayTransitionAction>();
		readonly HashSet<Task> runningTasks = new HashSet<Task>();
		public async Task runAll()
		{
			Debug.Assert( 0 == runningTasks.Count );
			foreach( var dta in list )
			{
				if( dta.IsThreadSafe )
				{
					// Thread safe tasks are started and finished on the thread pool's threads
					Func<Task> fnRun = dta.ProcessTransitionAsync;
					runningTasks.Add( Task.Run( fnRun ) );
				}
				else
				{
					// Non-thread safe tasks are started and finished on the GUI thread.
					// If they're not actually async, the following line will run the complete task.
					Task task  = dta.ProcessTransitionAsync();
					if( task.IsCompleted )
					{
						// It was a blocking task without await
						// Or maybe await that completed extremely fast.
						if( task.IsCompletedSuccessfully )
							OnIndividualItemProcessed();
						else
							await task;	// Propagate exception
					}
					else
						runningTasks.Add( task );
				}
			}
			while( runningTasks.Count > 0 )
			{
				runningTasks.Remove( await Task.WhenAny( runningTasks ) );
				OnIndividualItemProcessed();
			}
		}
	}
