    public class IDGJob : IJob
    {
        Action callback;
    
        public IDGJob(Action action)
        {
            if(action == null)
                throw new ArgumentNullException(nameof(action));
            callback = action;
        }
    
        public void Execute(IJobExecutionContext context)
        {
            callback();
        }
    }
