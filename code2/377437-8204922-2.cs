    //untested
    private bool _forceStop = false;
    private object _locker = new object();  // better not depend on queue here
    
    private void ProcessInBackground()
    {
        while(true)
        {
           // Moniter.Enter(queue);
           lock(_locker)
           {       
              while(!_forceStop && queue.Count == 0)
                Moniter.Wait(_locker);
    
              //Moniter.Exit(queue);
              if (_forceStop) break;
           
              object data = queue.Dequeue(); 
           }
           processData(data);
        }
    }
