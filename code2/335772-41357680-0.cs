    public void InitJob() {
        MyClass data = new MyClass {Foo = “Foo fighters”}; 
        /* a unique identifier for demonstration purposes.. Use your own concoction here. */
        int uniqueIdentifier = new Random().Next(int.MinValue, int.MaxValue); 
        IJobDetail newJob = JobBuilder.Create<MyAwesomeJob>()
        .UsingJobData("JobData", JsonConvert.SerializeObject(data))
        .WithIdentity($"job-{uniqueIdentifier}", "main")                
        .Build();
    }
    /* the execute method */
    public class MyAwesomeJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {                   
            var jobData = JsonConvert.DeserializeObject<MyClass>(context.JobDetail.JobDataMap.GetString("JobData"));    
        }
    }
    
    /* for completeness */
    public class MyClass {
    	string Foo { get; set; } 
    }
