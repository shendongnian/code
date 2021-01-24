    public static class MyLogger
    {
        public static void CreateLogger()
        {
            String logTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u}] [{SourceContext}] {Message}{NewLine}{Exception}";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console(outputTemplate: logTemplate)
                .WriteTo.File("log.txt", outputTemplate: logTemplate)
                .CreateLogger();
        }
    }
    
    class Program
    {
        static void Main(String[] args)
        {
            MyLogger.CreateLogger();
    
            Log.ForContext("SourceContext", "Main").Information("Start");
            Test1 t1 = new Test1();
    
            Console.ReadKey();
        }
    }
    
    class Test1
    {
        public Test1()
        {
            Log.ForContext("SourceContext", typeof(Test1).Name).Information("Test1 logg");
    
        }
    }
