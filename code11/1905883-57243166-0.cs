    //You can bind this to a Button or any other WPF event,
    // the point is that it should be run from UI thread
    private async void JobStartEvent()
    {
        JobResult jobResult = new JobResult
        {
            JobStatus = JobStatus.NotStarted
        };
        while (jobResult.JobStatus != JobStatus.Done)
        {
            jobResult = await DoLongJob(jobResult.ContinuationInfo);
            if (jobResult.JobStatus == JobStatus.UserPromptRequired)
            {
                jobResult.ContinuationInfo.PromptResult = PromptAndGetResult(jobResult.PromptInfo);
            }
        }
    }
    private async Task<JobResult> DoLongJob(JobContinuationInfo continuationInfo)
    {
        //Do long stuff here
        // continue the job using "continuationInfo"
        //When prompt needed, Do:
        {
            return new JobResult
            {
                JobStatus = JobStatus.UserPromptRequired,
                PromptInfo = new PromptInfo(), //Fill with information required for prompt
                ContinuationInfo = new ContinuationInfo() //Fill with information required for continuing the job (can be a delegate to a local function to continue the job)
            };
        }
        //When done, Do:
        {
            return new JobResult { JobStatus = JobStatus.Done};
        }
    }
    private async JobResult DoLongJob()
    {
        return JobResult = 
    }
    private enum JobStatus
    {
        NotStarted,
        UserPromptRequired,
        Done
    }
    internal class JobContinuationInfo
    {
        public PromptResult PromptResult { get; set; }
        // Other properties to continue the job
    }
    private class JobResult
    {
        public JobStatus JobStatus { get; set; }
        public PromptInfo PromptInfo { get; set; }
        public JobContinuationInfo ContinuationInfo { get; set; }
    }
