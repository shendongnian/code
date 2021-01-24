    protected override void OnStart(string[] args)
     {
         try
         {
                ServiceLogFile("Service is started at " + DateTime.Now);
                timer.AutoReset = false;
                timer.Elapsed += new ElapsedEventHandler(Autocancellation);
                timer.Interval = Int32.Parse(ConfigurationManager.AppSettings["tracktime"]); //number in miliseconds 
                timer.Enabled = true;
                timer.Start();
          }
          catch(Exception ex)
          {
               ServiceLogFile("Error in {OnStart} :" + ex.ToString());
          }
      }
    public void Autocancellation(object source, ElapsedEventArgs e)
    {
    	var needMore = false; // by default, no more timers.
    	try
    	{
    		lock (this)
    		{
    
    			//Database accesss
    			//select statement 
    
    			//Adding to Data table 
    			if(dt.Rows.Count>0)
    			{
    				needMore  = true;
    				//Update Statements 
    			}
    			else
    			{
    			   
    				 ServiceLogFile("There is no orders in the table Thread id :" +Thread.CurrentThread.ManagedThreadId);
    			 }
    		  }
       }
       finally
       {
          // next iteration of the timer, only if there are records.
    	  // otherwise, the timer will not be called.
    	  if(needMore)
    		timer.Start();
       }
    }
 
