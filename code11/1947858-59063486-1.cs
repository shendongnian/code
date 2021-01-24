    public class IDGJob : IJob
    {
        public event EventHandler Executed;
        public void Execute(IJobExecutionContext context)
        {
            Executed?.(this, EventArgs.Empty);
        }
    }
