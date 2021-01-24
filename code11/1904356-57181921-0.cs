    public void Run()
    {
            var processors1 = new CommonProcessor[] { new AProcessor(), new BProcessor() };  
            //AProcessor should be first!
            var processors2 = new CommonProcessor[] { new CProcessor(), new DProcessor() }; 
            //CProcessor should be first!
    
            Task task1 = RunSyncProcess(processors1);
            Task task2 = RunSyncProcess(processors2);
    
            Task.WhenAll(task1, task2);
    }
    
     private async Task RunSyncProcess(CommonProcessor[] processors)
     {
        while (true)
        {
             foreach (var processor in processors)
             { 
               // do some job 
             }
             await Task.Delay(TimeSpan.FromMilliseconds(frequency));//will free threadpool while waiting
        }
     }
