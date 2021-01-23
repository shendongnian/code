    public class TimerViewModel : INotifyPropertyChanged
    {
        public TimerViewModel()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            startTime = DateTime.Now;
        }
        private DispatcherTimer timer;
        private DateTime startTime;
        public event PropertyChangedEventHandler PropertyChanged;
        public TimeSpan TimeFromStart { get { return DateTime.Now - startTime; } }
        private void timer_Tick(object sender, EventArgs e)
        {
            RaisePropertyChanged("TimeFromStart");
        }
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
