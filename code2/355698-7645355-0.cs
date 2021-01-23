    protected void Application_Start()
    {
        Worker.Start();
    }
    
    ...
    
    public static class Worker
    {
        private static Timer timer = null;
        public static  void Start()
        {
            TimerCallback timerDelegate = new TimerCallback(Work);
            timer = new Timer(timerDelegate, null, 1200000, Timeout.Infinite);
        }
        public static void Work(object stateInfo)
        {
            // do stuff
        }
    }
