    public class UnityJobFactory : IJobFactory {
        public UnityJobFactory(IUnityContainer container) {
            Container = container;
        }
        public IUnityContainer Container { get; private set; }
        public IJob NewJob(TriggerFiredBundle bundle) {
            try {
                return Container.Resolve(bundle.JobDetail.JobType, null) as IJob;
            }
            catch (Exception exception) {
                throw new SchedulerException("Error on creation of new job", exception);
            }
        }
    }
