// configure Quartz
var stdSchedulerProperties = new NameValueCollection
{
	{ "quartz.threadPool.threadCount", "10" },
	{ "quartz.jobStore.misfireThreshold", "60000" }
};
var stdSchedulerFactory = new StdSchedulerFactory(stdSchedulerProperties);
var scheduler = stdSchedulerFactory.GetScheduler().Result;
scheduler.Start();
// create job and specify timeout
IJobDetail job = JobBuilder.Create<JobWithTimeout>()
	.WithIdentity("job1", "group1")
	.UsingJobData("timeoutInMinutes", 60)
	.Build();
// create trigger and specify repeat interval
ITrigger trigger = TriggerBuilder.Create()
	.WithIdentity("trigger1", "group1")
	.StartNow()
	.WithSimpleSchedule(x => x.WithIntervalInMinutes(15).RepeatForever())            
	.Build();
	
// schedule job	
scheduler.ScheduleJob(job, trigger).Wait();
/// <summary>
///     Implementation of IJob. Represents the wrapper job for a task with timeout
/// </summary>
public class JobWithTimeout : IJob
{
	public Task Execute(IJobExecutionContext context)
	{
		return Task.Run(() => Execute(context));
	}
	public void Execute(IJobExecutionContext context)
	{
	    Thread workerThread = new Thread(DoWork);
		workerThread.Start();
		context.JobDetail.JobDataMap.TryGetValue("timeoutInMinutes", out object timeoutInMinutes);
		TimeSpan timeout = TimeSpan.FromMinutes((int)timeoutInMinutes);
		bool finished = workerThread.Join(timeout);
		if (!finished) workerThread.Abort();
	}
	
	public void DoWork()
	{
		// do stuff
	}
}
