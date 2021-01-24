    public interface IHostedService {
        //
        // Summary:
        //     Triggered when the application host is ready to start the service.
        Task StartAsync(CancellationToken cancellationToken);
        //
        // Summary:
        //     Triggered when the application host is performing a graceful shutdown.
        Task StopAsync(CancellationToken cancellationToken);
    }
    public class SchedulerService : IHostedService {
        readonly IJobFactory jobFactory;
        readonly ISchedulerFactory schedulerFactory
        IScheduler  scheduler;
        public SchedulerService(IJobFactory jobFactory, ISchedulerFactory schedulerFactory) {
            this.jobFactory = jobFactory;
            this.schedulerFactory = schedulerFactory;
        }
        
        public async Task StartAsync(CancellationToken cancellationToken) {
            scheduler = await schedulerFactory.GetScheduler();
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
            
            await scheduler.Start(cancellationToken);
        }
        
        public Task StopAsync(CancellationToken cancellationToken) {
            return scheduler.Shutdown(cancellationToken);
        }
    }
    
