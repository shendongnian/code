    public class MyJobListener : IJobListener
    {
        public string Name () => "MyListener";
	    public Task JobToBeExecuted(IJobExecutionContext context){ }
	    public Task JobExecutionVetoed(IJobExecutionContext context){ }
	    public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            // Do after Job stuff....
        }
    }
