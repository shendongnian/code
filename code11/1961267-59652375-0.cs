    public class UrlWatcher
    {
        public string Url { get; set; }
        Timer timer { get; set; } = new Timer();
        DataService _dataService { get; set; }
        //Todo: Implement CancellationToken to gracefully stop the timer.
        //Event to report retrieved data
        public EventHandler<DataReceivedEventArgs> OnDataReceived; 
        public UrlWatcher(string Url, int TimerInterval = 2000)
        {
            //Use your implementation of DataService() here
            _dataService = new DataService(); 
            this.Url = Url;
            timer.AutoReset = false;
            timer.Interval = TimerInterval;
        }
        public void Start() // Call this to start polling the URL
        {
            timer.Start();
        }
        public async void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                var data = await _dataService.GetData(Url);
                OnDataReceived(this, new DataReceivedEventArgs(data));
            }
            finally
            {
                if (timer != null && !timer.Enabled) 
                { 
                    timer.Enabled = true;
                    timer.Start();
                }
            }
        }
    }
