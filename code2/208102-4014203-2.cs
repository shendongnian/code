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
        internal event DiskUsageResultHander DiskUsageResult;
        private void InitTimer()
        {
            StopTimer();
            _perfTimer = new Timer(_updateResolutionMillisecs);
            _perfTimer.Elapsed += PerfTimerElapsed;
            _perfTimer.Start();
        }
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
