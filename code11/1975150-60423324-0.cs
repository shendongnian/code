    public class CustomJobFactory : IJobFactory
    {
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var newJob = // Create job somehow
            ((ILoggerEnabledJob)newJob).AppLogger = LogManager.GetLogger(bundle.JobDetail.JobType.Name);
            return newJob;
        }
        public void ReturnJob(IJob job)
        {
            // ...
        }
    }
