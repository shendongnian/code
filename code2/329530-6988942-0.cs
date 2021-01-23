    //example using Thread class
    new Thread(() =>
    {
        if (Region1.Trim().Length > 0)
        {                
            returnMessage = ProcessMessage(string.Format(queueName, Region1));
            Logger.Log(returnMessage);
        }
    }) { IsBackground = true }.Start();
    
    //example using ThreadPool
    ThreadPool.QueueUserWorkItem(new WaitCallback((_) =>
    {
        if (Region2.Trim().Length > 0)
        {
            returnMessage = ProcessMessage(string.Format(queueName, Region2));
            Logger.Log(returnMessage);
        }
    }));
