    public void CreateTasks()                
    {                       
        _myData.ToObservable()
            .SelectMany(i => Observable.Start(DoSomething(i), Scheduler.NewThread))          
            .Subscribe(j => Console.WriteLine("j is {0}", j),                     
                () => Console.WriteLine("Completed"));    
    } 
 
