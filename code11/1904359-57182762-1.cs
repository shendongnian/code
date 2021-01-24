    public void Run()
    {
        var processors1 = new CommonProcessor[] { new AProcessor(), new BProcessor() };  
        //AProcessor should be first!
        var processors2 = new CommonProcessor[] { new CProcessor(), new DProcessor() }; 
        //CProcessor should be first!
        BackgroundJob.Enqueue(() => RunSyncProcess(processors1));
        BackgroundJob.Enqueue(() => RunSyncProcess(processors2));
    }
     public void RunSyncProcess(CommonProcessor[] processors)
     {
        while (true)
        {
             foreach (var processor in processors)
             { 
               // do some job 
             }
        }
     }
