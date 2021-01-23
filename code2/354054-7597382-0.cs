        public class TimerManager : INotifyPropertyChanged
        {
        private readonly DispatcherTimer dispatcherTimer;
        private TimeSpan durationTimeSpan;
        private string durationTime = "00:00:00";
        private DateTime startTime;
        private bool isStopped = true;
        readonly TimeSpan timeInterval = new TimeSpan(0, 0, 1);
        public event EventHandler Stopped;
        public TimerManager()
        {
            durationTimeSpan = new TimeSpan(0, 0, 0);
            durationTime = durationTimeSpan.ToString();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimerTick;
            dispatcherTimer.Interval = timeInterval;
            dispatcherTimer.IsEnabled = false;
            DefaultStopTime = new TimeSpan(17, 30, 0);
        }
        public TimerManager(TimeSpan defaultStopTime)
            : this()
        {
            DefaultStopTime = defaultStopTime;
        }
        #region Properties
        public TimeSpan ElapsedTime
        {
            get { return durationTimeSpan; }
        }
        public string DurationTime
        {
            get { return durationTime; }
            set
            {
                durationTime = value;
                OnPropertyChanged("DurationTime");
            }
        }
        public DateTime StartTime
        {
            get { return startTime; }
        }
        public bool IsTimerStopped
        {
            get
            {
                return isStopped;
            }
            set
            {
                isStopped = value;
                OnPropertyChanged("IsTimerStopped");
            }
        }
        public TimeSpan DefaultStopTime { get; set; }
        #endregion
        #region Start Stop Timer
        public void StartTimer()
        {
            dispatcherTimer.Start();
            durationTimeSpan = new TimeSpan(0,0,0);
            startTime = DateTime.Now;
            IsTimerStopped = false;
        }
        public void StopTimer()
        {
            dispatcherTimer.Stop();
            IsTimerStopped = true;
            if (Stopped != null)
            {
                Stopped(this, new EventArgs());
            }
        }
        #endregion
        public void DispatcherTimerTick(object sender, EventArgs e)
        {
           // durationTimeSpan = DateTime.Now - startTime;
           durationTimeSpan = durationTimeSpan.Add(timeInterval);
            DurationTime = string.Format("{0:d2}:{1:d2}:{2:d2}", durationTimeSpan.Hours, durationTimeSpan.Minutes,
                                         durationTimeSpan.Seconds);
            if (DateTime.Now.TimeOfDay >= DefaultStopTime)
            {
                StopTimer();
            }
        }
    }
