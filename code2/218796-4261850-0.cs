        void Run()
        {
          while(true)
             lock(this)
             {
                int timeToSleep = getTimeToSleep() //check your list and return a value
                if(timeToSleep <= 100) 
                    action...
                else
                {
    
                   int currTime = Datetime.Now;
    			   int currCount = yourList.Count;
                   try{
    			   do{
                     Monitor.Wait(this,timeToSleep);
                     
    				 if(Datetime.now >= (tomeToSleep + currtime))
    				      break; //time passed
    			     
                     else if(yourList.Count != currCount)
    					break; //new element added go check it
    				 currTime = Datetime.Now;
                   }while(true);
                }
    			}catch(ThreadInterruptedException e)
    			{
    			    //do cleanup code or check for shutdown notification
    			}
             }
          }
        }
    	
    void ScheduleEvent (Action action, DataTime time)
    {
    	lock(this)
    	{
    	   yourlist.add ...
    	   Monitor.Pulse(this);
    	
}
}
