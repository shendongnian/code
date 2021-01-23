    private int _seconds;
    public string TimeDisplay
    {
        get
        {
            TimeSpan ts = new TimeSpan( 0, 0, _seconds );
            return string.Format("{0,2:00}:{1,2:00}:{2,2:00}", ts.Minutes, ts.Minutes, ts.Seconds);
        }
    }
