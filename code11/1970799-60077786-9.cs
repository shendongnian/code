    public void Start()
    {
        this.Timer = new Timer();
        this.Timer.Interval = this.interval;
        this.Timer.Elapsed += Timer_Elapsed;
        this.Timer.Start();
    }
