        private static LoggerConfiguration GetLoggerConfiguration()
    {
        var config = new LoggerConfiguration()
            .ReadFrom.AppSettings(); // <<<<<<<<<<<< *#*#*#*#*#*#*#*#
        config = config.
           Enrich.WithProperty("ApplicationName", connectionString).
           Enrich.WithExceptionDetails().
           Enrich.WithMachineName().
           Enrich.WithProcessId().
           Enrich.WithThreadId().
           ReadFrom.AppSettings(); // <<<<<<<<<<<< *#*#*#*#*#*#*#*#
        return config;
    }
