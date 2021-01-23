    static class Program
    {
        private System.Timers.Timer _sleepTimer;
        private bool _isSleeping = false;
        private int _processTime;
        private int _noProcessTime;
        
        static void Main()
        {
            _processTime = 30000; //30 seconds
            _noProcessTime = 10000; //10 seconds
    
            this._sleepTimer = new System.Timers.Timer();
    
            this._sleepTimer.Interval = _processTime;
            this._sleepTimer.Elapsed += new System.Timers.ElapsedEventHandler(sleepTimer_Elapsed);
    
            ProcessTimer();
    
            this._sleepTimer.Start();
        }
    
        private void sleepTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ProcessTimer();
        }
    
        private void ProcessTimer()
        {
            _sleepTimer.Enabled = false;
    
            _isSleeping = !_isSleeping;
    
            if (_isSleeping)
            {
                _sleepTimer.Interval = _processTime;
                //process data HERE on new thread;
            }
            else
            {
                _sleepTimer.Interval = _noProcessTime;
                //wait fired thread and sleep
                Task.WaitAll(this.Tasks.ToArray());
            }
            _sleepTimer.Enabled = true;
        }
    }
