    private const int UpdateAllInterval = 30 * 1000;//30 seconds
    
    private readonly TimeSpan MinimumIntervalToUpdate = new TimeSpan(0, 0, 1);
    private ConcurrentDictionary<Data, DateTime> _dataUpdateFrequence = new ConcurrentDictionary<Data, DateTime>();
    private System.Timers.Timer _updateTimer = new System.Timers.Timer();
    //At the UI Constructor:
    public Window..
    {
        _updateTimer.Interval = UpdateAllInterval;
        _updateTimer.AutoReset = true;
        _updateTimer.Elapsed += OnUpdateTimerElapced;
        _updateTimer.Start();
    }
    private void OnUpdateTimerElapced(object sender, System.Timers.ElapsedEventArgs e)
    {
        this.Dispatcher.Invoke(/*update the UI method*/);//or this.Invoke if winforms
    }
    private void OnDataUpdated(Data data)
    {
        DateTime currentTime = DateTime.Now;
        DateTime lastUpdateTime = _dataUpdateFrequence.GetOrAdd(data, currentTime);
        bool needsUpdate = lastUpdateTime == currentTime || 
            currentTime > lastUpdateTime.Add(MinimumIntervalToUpdate);
        if (needsUpdate)
        {
            //Update the UI.
        }
        _dataUpdateFrequence.TryUpdate(data, currentTime, lastUpdateTime);
    }
