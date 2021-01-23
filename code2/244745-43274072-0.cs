     class Program
    {
        private static CancellationTokenSource _cancellationTokenSource;
        private static ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        private static Thread _serviceStartThread;
        private static Thread _serviceStopThread;
        private static int workcounter = 0;
        static void Main(string[] args)
        {
           
            _cancellationTokenSource = new CancellationTokenSource();
            _serviceStartThread = new Thread(DoWork);
            _serviceStopThread = new Thread(ScheduledStop);
            StartService();
            StopService();
        }
        private static void StartService()
        {
            _serviceStartThread.Start();
        }
        private static void StopService()
        {
            _serviceStopThread.Start();
        }
        /// <summary>
        /// Triggers a cancellation event for stopping the service in a timely fashion.
        /// </summary>
        private static void ScheduledStop()
        {
            while (!_shutdownEvent.WaitOne(0))
            {
                if (workcounter == 10)
                {
                    _cancellationTokenSource.Cancel();
                }
            }
        }
        /// <summary>
        /// Represents a long running Task with cancellation option
        /// </summary>
        private static void DoWork()
        {
            
            while (!_shutdownEvent.WaitOne(0))
            {
                if(!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    workcounter += 1;
                    Console.Write(Environment.NewLine);
                    Console.Write("Running...counter: " + workcounter.ToString());
                    Thread.Sleep(1000);//Not needed, just for demo..
                }
                else
                {
                    Console.Write(Environment.NewLine);
                    Console.Write("Recieved cancellation token,shutting down in 5 seconds.. counter: " + workcounter.ToString());
                    _shutdownEvent.Set();
                    Thread.Sleep(5000);//Not needed, just for demo..
                }
            }
        }
    }
