    public class Worker {
        private IJob job;
    
        public Worker(string jt) {
            job = JobFactory.GetJob(jt);
        }
    
        public void ProcessJob() {
             job.ProcessJob();
        }
    }
