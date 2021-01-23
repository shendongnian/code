    void QueueIt(long tick)
    {
        Task workTask = new Task(() => MyMethod());
    
        Task scheduleTask = Task.Factory.StartNew( () =>
        {                
            WaitUtil(tick); // Active waiting
            workTask.Start();
        });
    }
    
    
    void WaitUntil(long tick)
    {
        var toWait = tick - DateTime.Now.Ticks;
        System.Threading.Thread.Sleep(toWait);
    }
