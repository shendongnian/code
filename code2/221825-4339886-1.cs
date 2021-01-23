    myTimer.Interval = TimeSpan.FromSeconds(1);
    myTimer.Tick += delegate
    {
        this.OnPropertyChanged("TimeRemaining");
        if (this.TimeRemaining <= 0)
        {
            myTimer.Dispose();
        }
    };
    this.endTime = DateTime.UtcNow.AddMinutes(1);
    myTimer.Start();
    public int TimeRemaining
    {
        get { return (endTime - DateTime.UtcNow).TotalSeconds; }
    }
