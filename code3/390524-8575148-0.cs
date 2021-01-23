    public Task StartDoingSomeStuff(CallbackDelegate callback)
    {
        Task task = null;
        
        task = Task.Factory.StartNew(() =>
        {
             while(whatever)
             {
                 var results = DoSomeStuff();
                 callback(results, task); //CS0165. How do I get hold of the task?
             }
        });
    
        return task;
    }
