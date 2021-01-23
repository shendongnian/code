    namespace Example.Name.Space
    {
    public partial class SmsServices : ServiceBase
    {
        private static String _state = "";        
        private ManualResetEvent _stop = new ManualResetEvent(false);
        private static RegisteredWaitHandle _registeredWait;
        public WindowsServices()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {                        
            Logger.Write("Starting service", LoggerCategory.Information);            
            _stop.Reset();
            _registeredWait = ThreadPool.RegisterWaitForSingleObject(_stop,
                PeriodicProcess, null, 5000, false);
        }
        protected override void OnStop()
        {            
           // UpdateTimer.Stop();
            _stop.Set();
            Logger.Write("Stopping service", LoggerCategory.Information);
        }        
        private static void PeriodicProcess(object state, bool timedOut)
        {
            if (timedOut)
            {
                // Periodic processing here
                Logger.Write("Asserting thread state", LoggerCategory.Debug);
                lock (_state)
                {
                    if (_state.Equals("RUNNING"))
                    {
                        Logger.Write("Thread already running", LoggerCategory.Debug);
                        return;
                    }
                    Logger.Write("Starting thread", LoggerCategory.Debug);
                    _state = "RUNNING";
                }
                Logger.Write("Processing all messages", LoggerCategory.Information);
                //Do something 
                lock (_state)
                {
                    Logger.Write("Stopping thread", LoggerCategory.Debug);
                    _state = "STOPPED";
                }
            }
            else
                // Stop any more events coming along
                _registeredWait.Unregister(null);
            
            
        }
        }
    }
