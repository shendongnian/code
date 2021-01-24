    public class Foo
    {
       public bool IsIt()
       {
          var task = IsItAsync(); //no await here; we want the Task
          //this call blocks the current thread,
          //and unlike Run()/Wait() will use the current 
          //thread's TaskScheduler if able. 
          task.RunSynchronously(); 
          //if IsItAsync() can throw exceptions,
          //you still need a Wait() call to bring those back from the Task
          try{ 
              task.Wait();
              return task.Result;
          }
          catch(Exception ex) 
          { 
              //Handle IsItAsync() exceptions here;
              //remember to return something if you don't rethrow              
          }
       }
    
       public async Task<bool> IsItAsync()
       {
          // Some async logic
       }
    }
