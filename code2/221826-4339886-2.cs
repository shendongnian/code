    myTimer.Interval = TimeSpan.FromSeconds(1);
    myTimer.Tick += delegate
    {
        this.SecondsRemaining = this.SecondsRemaining - 1;
        if (this.SecondsRemaining == 0)
        {
            myTimer.Dispose();
        }
    };
    this.SecondsRemaining = 60;
    myTimer.Start();
    
    ...
    
    // assumes your class implements INotifyPropertyChanged and you have a helper method to raise OnPropertyChanged
    public int SecondsRemaining
    {
        get { return this.secondsRemaining; }
        private set
        {
            this.secondsRemaining = value;
            this.OnPropertyChanged(() => this.SecondsRemaining);
        }
    }
