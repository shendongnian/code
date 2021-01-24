    public class JobFactory : IJobFactory
    {
       private readonly IServiceProvider _serviceProvider;
      
       public JobFactory(IServiceProvider serviceProvider)
          => _serviceProvider = serviceProvider;
   
       public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
       {
          try
          {
             var jobDetail = bundle.JobDetail;
             var jobType = jobDetail.JobType;
             return _serviceProvider.GetService(jobType) as IJob;
          }
          catch (Exception ex)
          {
    
             throw new SchedulerException($"Problem instantiating class '{bundle.JobDetail.JobType.FullName}'", ex);
          }
       }
    
       public void ReturnJob(IJob job)
          => (job as IDisposable)?.Dispose();
    }
