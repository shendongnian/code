    private static Timer t;
    protected override void OnStart(string[] args)
    {
        t = new Timer(5000*60);
        t.Elapsed += new ElapsedEventHandler(OnTimedEvent)
        t.Start()
    }
    
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        // real code here
    }
