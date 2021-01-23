	using System;
	using System.Collections.Generic;
	using Quartz;
	using Quartz.Impl;
	     
	namespace Quartz1
	{
	    class Program
	    {
		    static void Main(string[] args)
		    {
			// construct a scheduler factory
			ISchedulerFactory schedFact = new StdSchedulerFactory();
		     
			// get a scheduler, start the schedular before triggers or anything else
			IScheduler sched = schedFact.GetScheduler();
			sched.Start();
		     
			// create job
			IJobDetail job = JobBuilder.Create<SimpleJob>()
				    .WithIdentity("job1", "group1")
				    .Build();
		     
			// create trigger
			ITrigger trigger = TriggerBuilder.Create()
			    .WithIdentity("trigger1", "group1")
			    .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever())
			    .Build();
		     
			// Schedule the job using the job and trigger 
			sched.ScheduleJob(job, trigger);
		     
		    }
	    }
	     
	    /// <summary>
	    /// SimpleJOb is just a class that implements IJOB interface. It implements just one method, Execute method
	    /// </summary>
	    public class SimpleJob : IJob
	    {
		    void IJob.Execute(IJobExecutionContext context)
		    {
			//throw new NotImplementedException();
			Console.WriteLine("Hello, JOb executed");
		    }
	    }
	} 
