    using Quartz;
    using Quartz.Impl;
    namespace MyProject.CommonObjects.Utilities
    {
      public static class QuartzFactory
      {
        private static object _locker = new object();
        private static IScheduler _schedulerInstance;
        public static IScheduler SchedulerInstance
        {
          get
          {
            lock (_locker)
            {
              if (_schedulerInstance == null)
                _schedulerInstance = StdSchedulerFactory.GetDefaultScheduler();
              return _schedulerInstance;
            }
          }
        }
      }
    }
