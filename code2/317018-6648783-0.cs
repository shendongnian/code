        static void Main(string[] args)
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            IScheduler sched = schedFact.GetScheduler();
            sched.Start();
            JobDetail jobDetail = new JobDetail("myJob", null, typeof(HelloJob));
            
            string scheduleFromDatabase="0 11 16 ? * FRI,SUN";
            CronTrigger trigger = new CronTrigger("trigger1", null, "myJob", null,scheduleFromDatabase );
            
            trigger.StartTimeUtc = DateTime.UtcNow;
            trigger.Name = "myTrigger";
            sched.ScheduleJob(jobDetail, trigger); 
        }
    public class HelloJob:IJob
    {
        public void Execute(JobExecutionContext context)
        {
            Console.WriteLine(DateTime.Now.ToString());
            //Call here your method!
        }
    }
