    public class DownloadFile
    {
        public string Url { get; set; }
        public string PathToSave { get; set; }
    }
    public class ParallelDownloading
        {
            private ConcurrentQueue<DownloadFile> _queueToDownlaod;
            private IList<Task> _downloadingTasks;
            private Timer _downloadTimer;
    
            public int ParallelDownloads { get; set; }
    
            public ParallelDownloading()
            {
                _queueToDownlaod = new ConcurrentQueue<DownloadFile>();
                _downloadingTasks = new List<Task>();
                _downloadTimer = new Timer();
    
                _downloadTimer.Elapsed += new ElapsedEventHandler(DownloadTimer_Elapsed);
                _downloadTimer.Interval = 1000;
                _downloadTimer.Start();
            }
    
            public void EnqueueFileToDownload(DownloadFile file)
            {
                _queueToDownlaod.Enqueue(file);
            }
    
            void DownloadTimer_Elapsed(object sender, ElapsedEventArgs e)
            {
                StartDownload();
            }
    
            private void StartDownload()
            {
                lock (_downloadingTasks)
                {
                    if (_downloadingTasks.Count < ParallelDownloads && _queueToDownlaod.Count > 0)
                    {
                        DownloadFile fileToDownload;
                        if (_queueToDownlaod.TryDequeue(out fileToDownload))
                        {
                            var task = new Task(() =>
                            {
                                var client = new WebClient();
                                client.DownloadFile(fileToDownload.Url, fileToDownload.PathToSave);
                            }, TaskCreationOptions.LongRunning);
    
                            _downloadingTasks.Add(task);
                            task.Start();
                        }   
                    }
                }
            }
