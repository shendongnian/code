    using System.Threading.Tasks;
    void CutoffAfterThreeSeconds() {
                
        // start function on seperate thread
        CancellationTokenSource cts = new CancellationTokenSource();
        Task loop = Task.Factory.StartNew(() => Loop(cts.Token));
                
        // wait for max 3 seconds
        if(Task.WaitAll(new Task[]{loop}, 3000)){
           // Loop finished withion 3 seconds
        } else {
           // it did not finish within 3 seconds
           // TODO: Cancel the running task in some way!
           // look into cancellation tokens for instance
        }        
    }
    
    // this one takes forever
    void Loop() {
        while (!ct.IsCancellationRequested) {
            // your loop goes here
        }
        Console.WriteLine("Got Cancelled");
    }
