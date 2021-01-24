    public void Run()
    {
        var processors1 = new CommonProcessor[] { new AProcessor(), new BProcessor() };  
        //AProcessor should be first!
        var processors2 = new CommonProcessor[] { new CProcessor(), new DProcessor() }; 
        //CProcessor should be first!
        Thread t1 = new Thread(() => RunSyncProcess(processors1));
        t1.Start();
        Thread t2 = new Thread(() => RunSyncProcess(processors1));
        t2.Start();
        t1.Join();
        t2.Join();
    }
    
     private void RunSyncProcess(CommonProcessor[] processors)
     {
        while (true)
        {
             foreach (var processor in processors)
             { 
               // do some job 
             }
             Thread.Sleep(frequency);
        }
     }
