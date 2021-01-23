    public ILogger Logger { get; set; }
    
    public MyController()
    {
         Logger = NullLogger.Instance;
    }
