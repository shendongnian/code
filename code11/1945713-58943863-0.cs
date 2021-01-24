    integer interval = 20;
    DateTime dueTime = DateTime.Now.AddMillisconds(interval);
    using(someThingDisposeable){
      while(true){
        if(DateTime.Now >= dueTime){
          //insert your work with someThingDisposeable here
    
          //Update next dueTime
    	  dueTime = DateTime.Now.AddMillisconds(interval);
        }
        else{
          //Just yield to not tax out the CPU
          Thread.Sleep(1);
        }
      }
    }
