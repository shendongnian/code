    // Tuple of the last time an id was processed and the id of the thing to schedule
    static List<Tuple<DateTime, int>> idsToSchedule = new List<Tuple<DateTime, int>>();
    
    // An event loop that performs the scheduling
    public static void SchedulingLoop()
    {
    	while (true)
    	{
    		lock (idsToSchedule)
    		{
    			DateTime currentTime = DateTime.Now;
    			for (int index = idsToSchedule.Count - 1; index >= 0; index--)
    			{
    				var scheduleItem = idsToSchedule[index];
    				var timeSincePreviousRun = (currentTime - scheduleItem.Item1).TotalSeconds;
    
    				// remove this from the list of things to schedule
    				idsToSchedule.RemoveAt(index);
    
    				// start it executing in a background task
    				if (timeSincePreviousRun > 2)
    				{
    					Console.WriteLine("Scheduling {0} after {1} seconds", scheduleItem.Item2, timeSincePreviousRun);
    
    					// Schedule this task to be processed
    					Task.Factory.StartNew(() =>
    						{
    							Console.WriteLine("Executing {0}", scheduleItem.Item2);
    
    							// simulate the time taken to call this procedure
    							Thread.Sleep(new Random((int)DateTime.Now.Ticks).Next(0, 5000) + 500);
    
    							lock (idsToSchedule)
    							{
    								idsToSchedule.Add(Tuple.Create(DateTime.Now, scheduleItem.Item2));
    							}
    
    							Console.WriteLine("Done Executing {0}", scheduleItem.Item2);
    						});
    					
    				}
    			}
    		}
    
    		Thread.Sleep(100);
    	}
    }
