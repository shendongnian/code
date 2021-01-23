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
    
            private int _parallelDownloads;
    
            public ParallelDownloading(int parallelDownloads)
            {
                _queueToDownlaod = new ConcurrentQueue<DownloadFile>();
                _downloadingTasks = new List<Task>();
                _downloadTimer = new Timer();
    
                _parallelDownloads = parallelDownloads;
    
                _downloadTimer.Elapsed += new ElapsedEventHandler(DownloadTimer_Elapsed);
                _downloadTimer.Interval = 1000;
                _downloadTimer.Start();
    
                ServicePointManager.DefaultConnectionLimit = parallelDownloads;
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
                    if (_downloadingTasks.Count < _parallelDownloads && _queueToDownlaod.Count > 0)
                    {
                        DownloadFile fileToDownload;
                        if (_queueToDownlaod.TryDequeue(out fileToDownload))
                        {
                            var task = new Task(() =>
                            {
                                var client = new WebClient();
                                client.DownloadFile(fileToDownload.Url, fileToDownload.PathToSave);
                            }, TaskCreationOptions.LongRunning);
    
                            task.ContinueWith(DownloadOverCallback, TaskContinuationOptions.None);
    
                            _downloadingTasks.Add(task);
                            task.Start();
                        }      
                    }
                }
            }
    
            public void DownloadOverCallback(Task downloadingTask)
            {
                lock (_downloadingTasks)
                {
                    _downloadingTasks.Remove(downloadingTask);
                }
            }
        }
