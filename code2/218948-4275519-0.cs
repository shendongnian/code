    public static void Main (string[] args)
    {
        try
    	{
    	    if (args.Length == 0)
    	    {
    	        throw new ArgumentException("No activity name given", "ActivityName");
    	    }
    	    //parameter 0 is the activity name
            string activityName = args[0];
    	    IScheduledActivity activity = ActivityFactory.GetActivity(activityName);
    				
    	    if (activityName != null)
    	    {
    	        activity.Execute(args);
    	    }
    	}
    	catch (Exception ex)
    	{
    	    Console.WriteLine("Error executing activity: " + ex.Message);
    	}
   }
