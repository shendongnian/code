    using Serilog;
    
    namespace xyz.Dispose
    {
        public class MyService
        {
            private readonly ILogger _log = Log.ForContext<MyService>();
    
            public void DoStuff()
            {
                _log.Information("This should appear in the log");
    
                // ...
            }
        }
    }
