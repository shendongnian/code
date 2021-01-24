    private void Stop_Click(object sender, EventArgs e)
    {
        // newPatient.startRnd = false;
        newPatient.PL(false);
    }
    class Patient : INotifyPropertyChanged
    {
        Timer timer;
        private Patient()
        {
            timer = new Timer();
            timer.AutoReset = true;
            timer.Interval = 1000;
            timer.Elapsed += PLS;
        }
        Random rnd = new Random();
        private int _pulseRate;
        public int PulseRate
        {
            get { return _pulseRate; }
            set
            {
                _pulseRate = value;
                OnPropertyChanged("PulseRate");
            }
        }
        public void PL(bool srt)
        {
            timer.Enabled = srt;
        }
        private void PLS(object sender, ElapsedEventArgs e)
        {
            PulseRate = rnd.Next(100, 150);
            Console.WriteLine(PulseRate);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string properyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }
        private static Patient _instance = null;
        private static readonly object _padlock = new object();
        public static Patient Instance
        {
            get
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new Patient();
                    }
                    return _instance;
                }
            }
        }
    }
