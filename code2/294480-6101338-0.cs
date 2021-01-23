		public static void Schedule(DateTime when, string applicationId)
		{
			ISchedulerFactory factory = new StdSchedulerFactory();
			IScheduler scheduler = factory.GetScheduler();
			JobDetail jobDetail = new JobDetail("Realization Job", null, typeof(CustomTask));
			jobDetail.JobDataMap["applicationId"] = applicationId;
			Trigger trigger = new SimpleTrigger("Custom Task Trigger", DateTime.UtcNow, null, 0, TimeSpan.Zero);
			scheduler.ScheduleJob(jobDetail, trigger);
		}
