    public static void Main(string[] args)
            {
                CurrentDirectoryHelpers.SetCurrentDirectory();
    
                Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Information()
                                .MinimumLevel.Override("Serilog", LogEventLevel.Information)
                                .WriteTo.File("Logs/LogFrom_ProgramMain.txt")
                                .CreateLogger();
    
                try
                {
                    var whb = WebHost.CreateDefaultBuilder(args).UseContentRoot(Directory.GetCurrentDirectory());
    
                   //whb... your codes
                    
                    Log.Logger.Information("Information:blabla");
    
                }
                catch(Exception ex)
                {
                    Log.Logger.Error("Main handled an exception: " + ex.Message);
                }
            }
