    public class DIJobFactory : IJobFactory
    {
        static ILogger<DIJobFactory> _logger;
        static IServiceProvider _serviceProvider;
        public DIJobFactory(ILogger<DIJobFactory> logger, IServiceProvider sp)
        {
            _logger = logger;
            _serviceProvider = sp;
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            IJobDetail jobDetail = bundle.JobDetail;
            Type jobType = jobDetail.JobType;
            try
            {
                _logger.LogDebug($"Producing instance of Job '{jobDetail.Key}', class={jobType.FullName}");
                if (jobType == null)
                {
                    throw new ArgumentNullException(nameof(jobType), "Cannot instantiate null");
                }
                return (IJob)_serviceProvider.GetRequiredService(jobType);
            }
            catch (Exception e)
            {
                SchedulerException se = new SchedulerException($"Problem instantiating class '{jobDetail.JobType.FullName}'", e);
                throw se;
            }
        }
        // get from https://github.com/quartznet/quartznet/blob/139aafa23728892b0a5ebf845ce28c3bfdb0bfe8/src/Quartz/Simpl/SimpleJobFactory.cs
        public void ReturnJob(IJob job)
        {
            var disposable = job as IDisposable;
            disposable?.Dispose();
        }
    }
