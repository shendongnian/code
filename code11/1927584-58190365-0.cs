    async Task Start()
    {
        //Method 1: fire all async event, then wait for all async task are completed
        //before handling all the results non asyncally
        List<Task<int>> FiredTasks = new List<Task<int>>();
        for (int i = 0; i< 6; i++)
        { 
            Debug.Log("async task firing "+i);
            Tasks.Add(DoAsyncTask("someStringValue", i));
        }
        
        foreach (int item in await Task.WhenAll(FiredTasks))
        {
            Debug.Log("async task ended, returned result: " + item);
            //add code to handle the returned result here.
        }
        //Method 2, fire all async event, then handle each result as they complete without waiting for others
        List<Task<int>> FiredTasks = new List<Task<int>>();
        for (int i = 0; i < 6; i++)
        {
            Debug.Log("Firing async event "+i);
            Tasks.Add(DoAsyncTask("someStringValue", i));
        }
        
        //If I understnd correctly, this loop basically tells each of the fired async task what to do when they are done.
        foreach (Task<int> task in FiredTasks)
        {
            await HandleAsyncResult(task);
        }
    }
    async Task<int> DoAsyncTask(string name, int index)
    {
        await Task.Delay(6000);
        // or you can do add some randome delay in here so you can see the individual task completing at different time
        await Task.Delay(UnityEngine.Random.Range(1,10) * 1000);
        return index;
    }
    async Task HandleAsyncResult(Task<int> task)
    {
        int taskResult = await task;
        Debug.Log("Done " + taskResult);
    }
