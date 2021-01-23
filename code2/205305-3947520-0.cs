	int count = ReadyQueue.Count;
    
    	// Copy Queue into Vector
    	List<Process> listProcesses = new List<Process>();
    
    	for(int i = 0; i < count; i++)
    	{
    		Process p = (Process)ReadyQueue.Dequeue();
    		listProcesses.Add(p);
    	}
    
    	// Sort Vector
    	listProcesses.Sort(CompareProcessesByPrediction);
    
    	// Copy Vector back into Queue
    	foreach(Process p in listProcesses)
    		ReadyQueue.Enqueue(p);
    
    
    private static int CompareProcessesByPrediction(Process proc1, Process proc2)
    {
    	//if they're both not-null, figure out which one is greatest/smallest.
    	//otherwise just pick the one that isn't null
    	if(proc1 == null)
    		return proc2 == null ? 0 : -1;
    	else
    		return proc1 == null ? 1 : proc1.last_prediction.CompareTo(proc2.last_prediction);
    }
