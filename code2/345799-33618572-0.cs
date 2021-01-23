    /// <summary>
    /// Custom Job Factory
    /// </summary>
    public class CustomJobFactory : SimpleJobFactory
    {
        /// <summary>
        /// Application context
        /// </summary>
        private IApplicationContext context;
    
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomJobFactory" /> class.
        /// </summary>
        public CustomJobFactory()
        {
            this.context = ContextRegistry.GetContext();
        }
    
        /// <summary>
        /// Creates a new job instance
        /// </summary>
        /// <param name="bundle">Trigger bundle</param>
        /// <param name="scheduler">Job scheduler</param>
        /// <returns></returns>
        public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            IJobDetail jobDetail = bundle.JobDetail;
            Type jobType = jobDetail.JobType;
            return this.context.GetObject(jobType.Name) as IJob;
        }
    
        /// <summary>
        /// Return job
        /// </summary>
        /// <param name="job">Job instance</param>
        public override void ReturnJob(IJob job)
        {
        }
    }
