    public class MyScheduler
    {
        static MyScheduler()
        {
            _schedulerFactory = new StdSchedulerFactory(getProperties());
            _scheduler = _schedulerFactory.GetScheduler();
        }
        public static IScheduler GetScheduler()
        {
            return _scheduler;
        }
    
        private static readonly ISchedulerFactory _schedulerFactory;
        private static readonly IScheduler _scheduler;
     }
