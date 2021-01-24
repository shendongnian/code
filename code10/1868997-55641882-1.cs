    private static ILog _log = LogManager.GetLogger(typeof(Program));
    static void Main(string[] args)
    {
       MyLoggerAdapter logAdapter = new MyLoggerAdapter(_log);
       var contentManager = new ContentManager(logAdapter);
       contentManager.Run();
    }
