    private TimeSpan _time;
    public TimeSpan Time 
    {
      get { return _time; }
      set 
      { 
        _time = value; 
        RaisePropertyChanged("Time");
      }
    }
    
    private int _minutes
    public int Minutes
    { 
      get { return _minutes; }
      set 
      {
        _minutes = value;
        CalculateTimeSpan();
        RaisePropertyChanged("Minutes");
      }
    }
    
    private int _seconds
    public int Seconds
    { 
      get { return _seconds; }
      set 
      {
        _seconds= value;
        CalculateTimeSpan();
        RaisePropertyChanged("Seconds");
      }
    }
   
