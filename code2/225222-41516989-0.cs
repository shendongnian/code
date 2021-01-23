    private DateTime _startTime;
    public DateTime StartTime 
    { 
        get { return _startTime; } 
        set 
        { 
            _startTime = value.AddSeconds(-value.Second)
                              .AddMilliseconds(-value.Millisecond);   
        }
    }
                            
