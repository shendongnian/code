        private static long _totalBytesReceivedAllFiles = 0;
        private static long _previousBytesReceivedForCurrentFile = 0;
        private static object _lock = new Object();
        private static void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // There are no guarantees in the documentation that such events are serialized and can't execute in parallel even for a single file,
            // thus we will use lock to at least partially serialize it and ensure atomic field access. 
            // !!!It is not intended to handle actual parallel downloads!!!
            lock (_lock)
            {
                _totalBytesReceivedAllFiles = _totalBytesReceivedAllFiles - _previousBytesReceivedForCurrentFile + e.BytesReceived;
                _previousBytesReceivedForCurrentFile = e.BytesReceived;
                Console.WriteLine($"Downloaded: {_totalBytesReceivedAllFiles} out of {totalBytes}");
                if (e.ProgressPercentage == 100)
                {
                    Console.WriteLine("Current file downloaded");
                    _previousBytesReceivedForCurrentFile = 0;
                }
            }
        }
