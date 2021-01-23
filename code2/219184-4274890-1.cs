    _globalJobListener = new GlobalJobListener();
    sched.AddGlobalJobListener(_globalJobListener);
    public class GlobalJobListener : Quartz.IJobListener
    {
    	public GlobalJobListener()
    	{
    	}
    
    	public virtual string Name
    	{
    		get { return "MainJobListener"; }
    	}
    
    	public virtual void JobToBeExecuted(JobExecutionContext context)
    	{		
    	}
    
    	public virtual void JobWasExecuted(JobExecutionContext inContext, JobExecutionException inException)
    	{
    		if (inException != null)
    		{
    			// Log/handle error here
    		}
    	}
    
    
    	public virtual void JobExecutionVetoed(JobExecutionContext inContext)
    	{
    
    	}
    }
