    public class PauseableTimer : Timer
    {
        private bool _paused;
        public bool Paused
        {
            get { return _paused; }
            set 
            { 
                Interval = _interval;
                _paused = value;
            }
        }
        new public bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                if (Paused)
                {
                    if (!value) base.Enabled = false;
                }
                else
                {
                    base.Enabled = value;
                }
            }
        }
        private double _interval;
        new public double Interval
        {
            get { return base.Interval; }
            set
            {
                _interval = value;
                if (Paused){return;}
                if (value>0){base.Interval = _interval;}
            }
        }
        public PauseableTimer():base(1){}
        public PauseableTimer(double interval):base(interval){}
    }
