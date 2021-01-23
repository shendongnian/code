    var tokenSource = new CancellationTokenSource();
    var task = Task.Factory.StartNew(() =>
    {
        for (int i = 0; i < 10; i++)
        {
            if (tokenSource.IsCancellationRequested)
            {
                //you know the task is cancelled
                //do something to stop the task
                //or you can use tokenSource.Token.ThrowIfCancellationRequested() 
                //to control the flow                
            }
            else
            {
                //working on step i
            }
        }
    }, tokenSource.Token);
    try
    {
        task.Wait(tokenSource.Token);
    }
    catch (OperationCanceledException cancelEx)
    { 
        //roll back or something
    }
    //somewhere e.g. a cancel button click event you call tokenSource.Cancel()
