    public partial class SomeService : ServiceBase
    {
        private Timer scheduler = null;
        private Timer Scheduler
        {
            get
            {
                if (this.scheduler == null)
                {
                    this.scheduler = new Timer(new TimerCallback(this.ProcessingFunction));
                }
                return this.scheduler;
            }
        }
        protected override void OnStart(string[] args)
        {
            // Set first .Change value to trigger initial execution.
        }
        protected override void OnStop()
        {
            this.Scheduler.Dispose();
        }
        private void ProcessingFunction(object e)
        {
            // Do stuff here
            // Calculate and set next execution time with .Change
        }
    }
