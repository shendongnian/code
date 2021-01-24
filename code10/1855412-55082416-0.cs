    public partial class MainWindow : Window
    {
        private BackgroundWorker _backgroundWorker;
        private Timer timer1;
        public MainWindow()
        {
            InitializeComponent();
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += backgroundWorker_DoWork;
            _backgroundWorker.RunWorkerAsync();
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            InitTimer();
        }
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Elapsed += Timer1OnElapsed;
            timer1.Interval = 2000; // in miliseconds
            timer1.Start();
        }
        private void Timer1OnElapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                TxtToBeUpdated.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                CallSocket();
            });
        }
        private void CallSocket()
        {
            //do socket 
        }
    }
