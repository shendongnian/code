    public class Basejob : IJob
    {
        public virtual void Execute(JobExecutionContext context)
        {
            string nextJob = context.MergedJobDataMap["nextjobname"];
            JobDetail nextjob = context.Scheduler.GetJobDetail(context.MergedJobDataMap["nextjobname"],
                                               context.MergedJobDataMap["nextjobgroupname"]);
            if(nextjob != null)
            {
                context.Scheduler.ScheduleJob(nextjob, new SimpleTrigger(nextjob.Name + "trigger")); // this will fire the job immediately
            }
        }
    }
    
    public class MyJob : BaseJob
    {
        public override void Execute(JobExecutionContext context)
        {
            //do work
            base.Execute(context);
        }
    }
