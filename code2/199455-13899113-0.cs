    public void Initialize()
    {
       var cancellationSource = new CancellationTokenSource();
       var cancellationToken = cancellationSource.Token;
       //Start both watchers
       var task1 = Task.Factory.StartNew(() => Watcher1(cancellationToken));
       var task2 = Task.Factory.StartNew(() => Watcher2(cancellationToken));
       
       //As an example, keep running the watchers until "stop" is entered in the console window
       while (Console.Readline() != "stop")
       {
       }
       //Trigger the cancellation...
       cancellationSource.Cancel();
       //...then wait for the tasks to finish.
       Task.WaitAll(new [] { task1, task2 });
    }
    
    public void Watcher1(CancellationToken cancellationToken)
    {
       while (!cancellationToken.IsCancellationRequested)
       {
          //Do stuff
       }
    }
    
    public void Watcher2(CancellationToken cancellationToken)
    {
       while (!cancellationToken.IsCancellationRequested)
       {
          //Do stuff
       }
    }
