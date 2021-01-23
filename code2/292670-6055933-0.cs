    public void DoWork()
    {
        var workId = new Random().Next(100);
    
        Console.WriteLine("Starting a long process ID: " + workId);
        LongProcess longProcess = new LongProcess();
        longProcess.StartWork();
        longProcess.OnWorkMiddle += ()=>{ Console.WriteLine("In middle of long process: " + workId);
        longProcess.OnWorkEnd += ()=>{ 
           Console.WriteLine("At the end of a long process");
           autoEvent.Set();
        };
    
        WaitHandle.WaitAll(new []{longProcess.autoEvent});
    }
