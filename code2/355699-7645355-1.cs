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
            int period = 1200000;
            timer = new Timer(new TimerCallback(Work), null, period, period);
        }
        public static void Work(object stateInfo)
        {
            // do stuff
        }
    }
