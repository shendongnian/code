    public class ReadCSVPeriodically
    {
        private static Timer _timer;
        private static Thread _readCSVDataThread;
        private static TimeSpan _startTimeSpan;
        private static TimeSpan _periodTimeSpan;  
		private static bool _stopFlag = false;		
        private static double _runInterval;
        private static long _inversedId;
		// Start The process
        public void Start(double RunInterval = 15 )
        {
            _runInterval = RunInterval;
            if (_readCSVDataThread == null)
            {
                _readCSVDataThread = new Thread(new ThreadStart(ReadNewCSVData));
                _readCSVDataThread.Start();
                _readCSVDataThread.IsBackground = true;
            }            
        }
		 /// <summary>
        /// This method stop the thread.
        /// </summary>
        public void Stop()
        {
            try
            {
                do
                {
                    Thread.Sleep(10000);
                    i++;
                } while (_stopFlag == false);
                if (_stopFlag == true)
                {
                    DisposeOfTimer();
                    if (_readCSVDataThread != null)
                    {
                        killThread();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
		/// <summary>
        ///  New thread method for CSV parsing periodically
        /// </summary>
        private void ReadNewCSVData()
        {
            _startTimeSpan = TimeSpan.Zero;
            if (_runInterval == 0)
            {
                _periodTimeSpan = TimeSpan.FromMinutes(Your default time interval);
            }
            else
            {
                _periodTimeSpan = TimeSpan.FromMinutes(_runInterval);
            }
            // Call the method to parse csv
            _timer = new Timer((e) =>
            {
                ReadNewCSVMethod();
            }, null, _startTimeSpan, _periodTimeSpan);
        }
		
		// CSV parser
		private List<CSV Data row model> ReadNewCSVMethod()
		{
			//Parse CSV file and prepare		
			// You can use any CSV parser or write a simple method to read csv
		}
	}
	}
