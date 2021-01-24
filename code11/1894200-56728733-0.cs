    public class SchedulerService : IHostedService {
        readonly IJobFactory jobFactory;
        readonly ISchedulerFactory schedulerFactory
        
        public SchedulerService(IJobFactory jobFactory, ISchedulerFactory schedulerFactory) {
            this.jobFactory = jobFactory;
            this.schedulerFactory = schedulerFactory;
        }
        
        public async Task StartAsync(CancellationToken cancellationToken) {
            IScheduler  scheduler = await schedulerFactory.GetScheduler();
            scheduler.JobFactory = jobFactory;
            
            IJobDetail job = JobBuilder.Create<Job1>()
                .WithIdentity("job1")
                .Build();
                
            ITrigger  trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(1)
                    .RepeatForever())
                .Build();
                
            await scheduler.ScheduleJob(job, trigger);
            
            await scheduler.Start();
        }
        
        //...code omitted for brevity
    }
    
