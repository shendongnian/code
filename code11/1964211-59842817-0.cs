    using Serilog;
    using Serilog.Sinks.MSSqlServer;
    
    Log.Logger = new LoggerConfiguration()
                    .WriteTo
                    .MSSqlServer(
                        connectionString: hangfireConnectionString,
                        tableName: "Logs",
                        autoCreateSqlTable: true
                    ).CreateLogger();
               //will display any issues with Serilog config.  comment out in prod.
               Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
    
                GlobalConfiguration
                    .Configuration
                    .UseSqlServerStorage(hangfireConnectionString)
                    .UseSerilogLogProvider();
