	public partial class MainForm : Form
	{
		IScheduler sched;
		IJobDetail job;
		public MainForm()
		{
			InitializeComponent();
			ISchedulerFactory sf = new StdSchedulerFactory();
			IScheduler sched = sf.GetScheduler();
			DateTimeOffset runTime = DateBuilder.EvenMinuteDate(DateTime.UtcNow);
			DateTimeOffset startTime = DateBuilder.NextGivenSecondDate(null, 10);
			job = JobBuilder.Create<HelloJob>()
				.WithIdentity("job1", "group1")
				.Build();
			ITrigger trigger = TriggerBuilder.Create()
				.WithIdentity("trigger1", "group1")
				.StartAt(runTime)
				.WithCronSchedule("5 0/1 * * * ?")
				.Build();
			sched.ScheduleJob(job, trigger);
		}
		private void startScheduler_Click(object sender, EventArgs e)
		{
			sched.Start();
		}
		private void startJob_Click(object sender, EventArgs e)
		{
			sched.TriggerJob(job.Name, job.Group);
		}
	}
