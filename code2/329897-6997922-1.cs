    var complete = false;
    var startTime = DateTime.Now;
    var timeout = new TimeSpan(0,0,30); //a thirty-second timeout.
    
    //We'll loop as many times as we have to; how we exit this loop is dependent only
    //on whether it finished within 30 seconds or not.
    while(!complete && DateTime.Now < startTime.Add(timeout))
    {
       //A property indicating status; properties should be simpler in function than methods.
       //this one could even be a field.
       if(Thing.WereWaitingOnIsComplete)
       {
          complete = true;
          break;
       }
       
       //Signals the OS to suspend this thread and run any others that require CPU time.
       //the OS controls when we return, which will likely be far sooner than your Sleep().
       Thread.Yield();
    }
    //Reduce dependence on Thing using our local.
    if(!complete) throw new TimeoutException();
