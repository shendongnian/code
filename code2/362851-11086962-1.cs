    public PostDownloadJobListener : IJobListener
    {
        string Name { get { return "MyJobListener"; } }
        void JobToBeExecuted(JobExecutionContext context) { }
        void JobExecutionVetoed(JobExecutionContext context) { }
        void JobWasExecuted(JobExecutionContext context, JobExecutionException jobException)
        {
            // Perform processing here
        }
    }
