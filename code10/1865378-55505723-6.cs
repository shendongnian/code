    public class ImportJob : IJob
    {
        private readonly SContext _db;
    
        //Quartz.net doesn't appear to like that I'm injecting these, 
        //because if I remove this parameter, execute...executes.
        public ImportJob(SContext db)
        {
            _db = db;
        }
    
        public Task Execute(IJobExecutionContext context)
        {
            var cc = new CC(_db);
            return Task.CompletedTask;
        }
    }
