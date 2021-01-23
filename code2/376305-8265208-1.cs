    public class RequestsPerSecondCollector
    {
        #region General Declaration
        //Static Stuff for the polling timer
        private static System.Threading.Timer pollingTimer;
        private static int stateCounter = 0;
        private static int lockTimerCounter = 0;
    
        //Instance Stuff for our performance counter
        private static System.Diagnostics.PerformanceCounter pcReqsPerSec;
        private readonly static object threadLock = new object();
        private static decimal CurrentRequestsPerSecondValue;
        private static int LastRequestTicks;
        #endregion
    
        #region Singleton Implementation
        /// <summary>
        /// Static members are 'eagerly initialized', that is, 
        /// immediately when class is loaded for the first time.
        /// .NET guarantees thread safety for static initialization.
        /// </summary>
        private static readonly RequestsPerSecondCollector _instance = new RequestsPerSecondCollector();
        #endregion
    
        #region Constructor/Finalizer
        /// <summary>
        /// Private constructor for static singleton instance construction, you won't be able to instantiate this class outside of itself.
        /// </summary>
        private RequestsPerSecondCollector()
        {
            LastRequestTicks = System.Environment.TickCount;
    
            // Start things up by making the first request.
            GetRequestsPerSecond();
        }
        #endregion
    
        #region Getter for current requests per second measure
        public static decimal GetRequestsPerSecond()
        {
            if (pollingTimer == null)
            {
                Console.WriteLine("Starting Poll Timer");
    
                // Let's check the performance counter every 1 second, and don't do the first time until after 1 second.
                pollingTimer = new System.Threading.Timer(OnTimerCallback, null, 1000, 1000);
    
                // The first read from a performance counter is notoriously inaccurate, so 
                OnTimerCallback(null);
            }
    
            LastRequestTicks = System.Environment.TickCount;
            lock (threadLock)
            {
                return CurrentRequestsPerSecondValue;
            }
        }
        #endregion
    
        #region Polling Timer
        static void OnTimerCallback(object state)
        {
            if (System.Threading.Interlocked.CompareExchange(ref lockTimerCounter, 1, 0) == 0)
            {
                if (pcReqsPerSec == null)
                    pcReqsPerSec = new System.Diagnostics.PerformanceCounter("W3SVC_W3WP", "Requests / Sec", "_Total", true);
    
                if (pcReqsPerSec != null)
                {
                    try
                    {
                        lock (threadLock)
                        {
                            CurrentRequestsPerSecondValue = Convert.ToDecimal(pcReqsPerSec.NextValue().ToString("N2"));
                        }
                    }
                    catch (Exception) {
                        // We had problem, just get rid of the performance counter and we'll rebuild it next revision
                        if (pcReqsPerSec != null)
                        {
                            pcReqsPerSec.Close();
                            pcReqsPerSec.Dispose();
                            pcReqsPerSec = null;
                        }
                    }
                }
    
                stateCounter++;
    
                //Check every 5 seconds or so if anybody is still monitoring the server PerformanceCounter, if not shut down our PerformanceCounter
                if (stateCounter % 5 == 0)
                {
                    if (System.Environment.TickCount - LastRequestTicks > 5000)
                    {
                        Console.WriteLine("Stopping Poll Timer");
    
                        pollingTimer.Dispose();
                        pollingTimer = null;
    
                        if (pcReqsPerSec != null)
                        {
                            pcReqsPerSec.Close();
                            pcReqsPerSec.Dispose();
                            pcReqsPerSec = null;
                        }
                    }                                                      
                }
    
                System.Threading.Interlocked.Add(ref lockTimerCounter, -1);
            }
        }
        #endregion
    }
