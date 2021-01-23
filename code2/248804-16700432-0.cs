        public void Run()
        {
            // construct a scheduler factory
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler();
            IJobDetail job = JobBuilder.Create<TaskOne>()
                    .WithIdentity("TaskOne", "TaskOneGroup")
                    .Build();
            ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("TaskOne", "TaskOneGroup")
            .StartNow()
            .WithSimpleSchedule(x => x.WithIntervalInSeconds(20).RepeatForever())
            .Build();
            _scheduler.ScheduleJob(job, trigger);
            _scheduler.TriggerJob(job.Key);
            _scheduler.Start();
        }
