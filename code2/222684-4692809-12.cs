    CancellationTokenSource cts = new CancellationTokenSource();
    ParallelOptions po = new ParallelOptions();
    po.CancellationToken = cts.Token;
    po.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
    
    Parallel.ForEach(iListOfItems, po, (item, loopState) =>
    {
        
    	using (cts.Token.Register(Thread.CurrentThread.Abort))
        {
            Try
            {
               Thread.Sleep(120000); // pretend web service call          
            }
            Catch(ThreadAbortException ex)
            {
               // log etc.
            }
            Finally
            {
              // clean up here
            }
        }
        
    });
