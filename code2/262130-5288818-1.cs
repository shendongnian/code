    public class YourService
    {
        private System.Threading.Timer _timer;
        
        protected override void OnStart(string[] args)
        {
            //run once in 5 seconds.
            _timer = new System.Threading.Timer(WorkerMethod, null, 5000, Timeout.Infinite);
        }
        
        protected override void OnStop()
        {
            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }
        }
        void WorkerMethod(object state)
        {
            // Processing code here
            _worker.Change(5000, Timeout.Infinite); //Run again in 5 seconds
        }
    }
