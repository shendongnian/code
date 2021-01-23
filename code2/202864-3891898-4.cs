        private int numticks = 0;
        private Timer _timer;
        private bool _IsStarted;
        private int Interval =2000; //ticks //2 sec.
        #region Initializer
        public YourServrClass()
		{
			InitializeComponent();
			_timer = new Timer();
			 _timer.Interval = Interval;
			_timer.Elapsed += new ElapsedEventHandler(this.Timer_Tick);
        }
        #endregion
        #region Timer_Tick to process
        private void Timer_Tick(object sender, System.Timers.ElapsedEventArgs e)
		{
			numticks++;
			if (_IsStarted)
			{
				_timer.Stop();
				//your code //ProcessYourData();
				_timer.Start();
			}
        }
        #endregion
        protected override void OnStart(string[] args) 
        { 
               _IsStarted=true;
        } 
        protected override void OnStop() 
        { 
              _IsStarted=false;
        } 
}
