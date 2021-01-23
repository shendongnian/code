    public struct DiskUsageStats
    {
        public int DiskQueueLength;
        public int DiskUsagePercent;
        public string DriveName;
        public int ReadBytesPerSec;
        public int WriteBytesPerSec;
    }
    internal class DiskUsageMonitor
    {
        private readonly PerformanceCounter _diskQueueCounter;
        private readonly PerformanceCounter _idleCounter;
        private Timer _perfTimer;
        private readonly PerformanceCounter _readBytesCounter;
        private int _updateResolutionMillisecs = 100;
        private readonly PerformanceCounter _writeBytesCounter;
        /// <summary>
        /// Initializes a new instance of the <see cref="DiskUsageMonitor"/> class.
        /// </summary>
        /// <param name="updateResolutionMillisecs">The update resolution millisecs.</param>
        internal DiskUsageMonitor(int updateResolutionMillisecs)
            : this(null)
        {
            _updateResolutionMillisecs = updateResolutionMillisecs;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DiskUsageMonitor"/> class.
        /// </summary>
        /// <param name="updateResolutionMillisecs">The update resolution millisecs.</param>
        /// <param name="driveName">Name of the drive.</param>
        internal DiskUsageMonitor(int updateResolutionMillisecs, string driveName)
            : this(driveName)
        {
            _updateResolutionMillisecs = updateResolutionMillisecs;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DiskUsageMonitor"/> class.
        /// </summary>
        /// <param name="driveName">Name of the drive.</param>
        internal DiskUsageMonitor(string driveName)
        {
            // Get a list of the counters and look for "C:"
            var perfCategory = new PerformanceCounterCategory("PhysicalDisk");
            string[] instanceNames = perfCategory.GetInstanceNames();
            foreach (string name in instanceNames)
            {
                if (name.IndexOf("C:") > 0)
                {
                    if (string.IsNullOrEmpty(driveName))
                        driveName = name;
                }
            }
            _readBytesCounter = new PerformanceCounter("PhysicalDisk", "Disk Read Bytes/sec", driveName);
            _writeBytesCounter = new PerformanceCounter("PhysicalDisk", "Disk Write Bytes/sec", driveName);
            _diskQueueCounter = new PerformanceCounter("PhysicalDisk", "Current Disk Queue Length", driveName);
            _idleCounter = new PerformanceCounter("PhysicalDisk", "% Idle Time", driveName);
            InitTimer();
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        internal DiskUsageMonitor()
            : this(null)
        {
        }
        /// <summary>
        /// Gets or sets the update interval milli secs.
        /// </summary>
        /// <value>The update interval milli secs.</value>
        public int UpdateIntervalMilliSecs
        {
            get { return _updateResolutionMillisecs; }
            set
            {
                _updateResolutionMillisecs = value;
                InitTimer();
            }
        }
        internal event DiskUsageResultHander DiskUsageResult;
        /// <summary>
        /// Inits the timer.
        /// </summary>
        private void InitTimer()
        {
            StopTimer();
            _perfTimer = new Timer(_updateResolutionMillisecs);
            _perfTimer.Elapsed += PerfTimerElapsed;
            _perfTimer.Start();
        }
        /// <summary>
        /// Performance counter timer elapsed event handler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private void PerfTimerElapsed(object sender, ElapsedEventArgs e)
        {
            float diskReads = _readBytesCounter.NextValue();
            float diskWrites = _writeBytesCounter.NextValue();
            float diskQueue = _diskQueueCounter.NextValue();
            float idlePercent = _idleCounter.NextValue();
            if (idlePercent > 100)
            {
                idlePercent = 100;
            }
            if (DiskUsageResult != null)
            {
                var stats = new DiskUsageStats
                                {
                                    DriveName = _readBytesCounter.InstanceName,
                                    DiskQueueLength = (int)diskQueue,
                                    ReadBytesPerSec = (int)diskReads,
                                    WriteBytesPerSec = (int)diskWrites,
                                    DiskUsagePercent = 100 - (int)idlePercent
                                };
                DiskUsageResult(stats);
            }
        }
        /// <summary>
        /// Stops the timer.
        /// </summary>
        internal void StopTimer() {
            if (_perfTimer != null) {
                try {
                    _perfTimer.Stop();
                } catch {
                } finally {
                    _perfTimer.Close();
                    _perfTimer.Dispose();
                    _perfTimer.Elapsed -= PerfTimerElapsed;
                    _perfTimer = null;
                }
            }
        }
        /// <summary>
        /// Closes this instance.
        /// </summary>
        internal void Close()
        {
            StopTimer();
            DiskUsageResult = null;
        }
        #region Nested type: DiskUsageResultHander
        internal delegate void DiskUsageResultHander(DiskUsageStats diskStats);
        #endregion
    }
