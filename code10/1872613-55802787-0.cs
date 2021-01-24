    public class SharedJobs
    {
        private readonly ConcurrentDictionary<string, Job> _jobs
            = new ConcurrentDictionary<string, Job>();
        public ConcurrentDictionary<string, Job> Jobs => _jobs;
    }
