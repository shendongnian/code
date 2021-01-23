       public IObservable<int> DoSomethingAsync(int j)        
       {             
          return Observable.Defer<int>(() =>
          {
             return Observable.Start<int>(() => DoSomething(j));
          }
       }
   
       public void CreateTasks()            
       {                
          _myData.ToObservable(Scheduler.NewThread)
             .SelectMany(i => DoSomethingAsync(i))
             .Subscribe(j => Console.WriteLine("j is {0}", j)),
                        () => Console.WriteLine("Completed"));
       }
