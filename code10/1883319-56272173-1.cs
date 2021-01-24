    public sealed partial class Window1 : Window, IDisposable
    {
        private readonly System.Timers.Timer _timer = new System.Timers.Timer(TimeSpan.FromSeconds(2).Milliseconds);
        public Window1()
        {
            InitializeComponent();
            _timer.Elapsed += _timer_Elapsed;
        }
        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Process.GetProcessesByName("processName...").Length == 0)
            {
                _timer.Stop();
                _timer.Dispose();
                //do something...
            }
        }
        public void Dispose()
        {
            _timer.Dispose();
        }
    }
