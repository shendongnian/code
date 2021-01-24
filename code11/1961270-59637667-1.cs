    public class Foo
    {
       public bool IsIt()
       {
          var task = IsItAsync(); //no await here; we want the Task
          //Some tasks end up scheduled to run before you get them;
          //don't try to run them a second time
          if((int)task.Status > (int)TaskStatus.Created)
              //this call will block the current thread,
              //and unlike Run()/Wait() will prefer the current 
              //thread's TaskScheduler instead of a new thread.
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
