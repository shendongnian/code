      public MainWindowViewModel()
      {
         PropertyChanged += PropertyChangedHandler;
         StartServer = new DelegateCommand<object>(
            context =>
            {
               ServerIsRunning = true;
            }, e => !ServerIsRunning);
         StopServer = new DelegateCommand<object>(
            context =>    {
               ServerIsRunning = false;
            }, e => ServerIsRunning);
      }
      public DelegateCommand<object> StartServer
      { get; }
      public DelegateCommand<object> StopServer
      { get; }
