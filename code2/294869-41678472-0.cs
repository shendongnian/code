    [assembly: PreApplicationStartMethod(typeof(Bootstraper), "Start")]
    [assembly: ApplicationShutdownMethod(typeof(Bootstraper), "End")]
    public static class Bootstraper
    {
        public static void End()
        {
            ...
        }
        public static void Start()
        {
            ...
        }
    }
