    Worker worker = new HouseMaid();
    try
    {
        worker.DoSomeWork();
    }
    catch(WorkerIsSickException ex)
    {
    	worker.TakeMedicin();
    	worker.StopWorkingAndRestForAWhile();
    }
