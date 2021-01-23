    [Browsable(false)]
    public DateTime DateTime { get; set; }
    
    public DateTime Date
    {
        get { return this.DateTime.Date; }
        set
        {
            TimeSpan time = this.Time;
            this.DateTime = value.Date + time;
        }
    }
    
    public TimeSpan Time
    {
        get { return this.DateTime.TimeOfDay; }
        set
        {
            this.DateTime = this.Date + value;
        }
    }
