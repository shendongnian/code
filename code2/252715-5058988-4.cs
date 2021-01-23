    public void CreateTasks()                
    {                       
        _myData.ToObservable(Scheduler.NewThread)
            .SelectMany(i => Observable.Start(() => DoSomething(i)))
            .Subscribe(j => Console.WriteLine("j is {0}", j), 
                      () => Console.WriteLine("Completed"));       
    } 
 
