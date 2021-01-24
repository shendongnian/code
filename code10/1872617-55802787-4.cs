    public class SharedJobs
    {
        private readonly ConcurrentDictionary<string, Job> _jobs
            = new ConcurrentDictionary<string, Job>();
        public Job Get(string key)
        {
            return _jobs.GetOrAdd(key, CreateNewJob());
        }
        private Job CreateNewJob() {}
    }
