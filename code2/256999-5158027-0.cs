    public interface IJobDetails {
        public void DoSomeWork();
    }
    public abstract BaseJob {
    
        protected abstract IJobDetails JobDetails { get; set; }
    
        public ExecuteJob {
            //execute the job
            JobDetails.DoSomeWork();
        }
    }
    
    public Job1 : BaseJob {
        public Job1() {
            JobDetails = new ConcreteJobDetails();
        }
        protected override IJobDetails JobDetails { get; set; }
    }
