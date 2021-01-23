    CancellationTokenSource cts = new CancellationTokenSource();
    Task task1 = new Task(() => {
        while(true){
            if(cts.Token.IsCancellationRequested)
                break;
        }
    }, cts.Token);
    task1.ContinueWith((ant) => {
        // Perform task1 post-cancellation logic.
        // This will NOT fire when calling cst.Cancel().
    }
    
    Task task2 = new Task(() => {
        while(true){
            cts.Token.ThrowIfCancellationRequested();
        }
    }, cts.Token);
    task2.ContinueWith((ant) => {
        // Perform task2 post-cancellation logic.
        // This will fire when calling cst.Cancel().
    }
    task1.Start();
    task2.Start();
    Thread.Sleep(3000);
    cts.Cancel();
