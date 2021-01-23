    Worker worker = new HouseMaid();
    try
    {
        Worker otherWorker = new HouseMaidHelper();
    	
    	worker.DelegateWorkTo(otherWorker, CallBackWhenOTherWorkerIsDone);
    	
    	worker.GoOnDoSomethingElse();
    }
    catch(WorkerIsSickException ex)
    {
    	worker.TakeMedicin();
    	worker.StopWorkingAndRestForAWhile();
    }
