    TaskScheduler uiScheduler;
    public MainWindowViewModel() 
    {
        uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        Track _Track = new Track();
        _Track.OnResponseEvent += new Track.ResponseEventHandler(UpdateTrackResponseWindow);
    }
