        public class TestTimer : INotifyPropertyChanged
        {
            private string _timeFormat;
            public int Minutes { get; private set; }
            public int Seconds { get; private set; }
            public int Hours { get; private set; }
            public DispatcherTimer Timer { get; private set; }
            public string TimeFormat
            {
                get { return _timeFormat; }
                private set
                {
                    _timeFormat = value;
                    OnPropertyChanged(nameof(TimeFormat));
                }
            }
    
            public TestTimer()
            {
                StartTimer();
            }
    
            public void StartTimer()
            {
                Timer = new DispatcherTimer();
                Timer.Interval = new TimeSpan(0, 0, 1);
                Timer.Tick += TimerTick;
                Timer.Start();
            }
    
            private async void TimerTick(object sender, EventArgs e)
            {
                await Task.Run(() => TimerCycle());
            }
    
            private void TimerCycle()
            {
                for (; ; )
                {
                    if (Seconds > 59)
                    {
                        Seconds = 0;
                        Minutes++;
    
                        if (Minutes > 59)
                        {
                            Minutes = 0;
                            Hours++;
    
                            if (Hours > 23)
                                Hours = 0;
                        }
                    }
                    Seconds++;
    
                    TimeFormat = string.Format("{0:00}:{1:00}:{2:00}",
                        Hours, Minutes, Seconds);
                    Thread.Sleep(200);
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
