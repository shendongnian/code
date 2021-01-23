        private static bool StartProcess(string filePath, string processName)
        {
            if (!File.Exists(filePath))
                throw new InvalidOperationException($"Unknown filepath: {(string.IsNullOrEmpty(filePath) ? "EMPTY PATH" : filePath)}");
            var isRunning = false;
            using (var resetEvent = new ManualResetEvent(false))
            {
                void Callback(object state)
                {
                    if (!IsProcessActive(processName)) return;
                    isRunning = true;
                    // ReSharper disable once AccessToDisposedClosure
                    resetEvent.Set();
                }
                using (new Timer(Callback, null, 0, TimeSpan.FromSeconds(0.5).Milliseconds))
                {
                    Process.Start(filePath);
                    WaitHandle.WaitAny(new WaitHandle[] { resetEvent }, TimeSpan.FromSeconds(9));
                }
            }
            return isRunning;
        }
        private static bool StopProcess(string processName)
        {
            if (!IsProcessActive(processName)) return true;
            var isRunning = true;
            using (var resetEvent = new ManualResetEvent(false))
            {
                void Callback(object state)
                {
                    if (IsProcessActive(processName)) return;
                    isRunning = false;
                    // ReSharper disable once AccessToDisposedClosure
                    resetEvent.Set();
                }
                using (new Timer(Callback, null, 0, TimeSpan.FromSeconds(0.5).Milliseconds))
                {
                    foreach (var process in Process.GetProcessesByName(processName))
                        process.Kill();
                    WaitHandle.WaitAny(new WaitHandle[] { resetEvent }, TimeSpan.FromSeconds(9));
                }
            }
            return isRunning;
        }
        
        private static bool IsProcessActive(string processName)
        {
            return Process.GetProcessesByName(processName).Any();
        }
