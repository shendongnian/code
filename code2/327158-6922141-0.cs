    public LoggingConfigurationProvider : ILoggingConfigurationProvider {
     public LoggingConfigurationProvider() {
       // load both values from configuration file
     }
    
     public string LogPath { get; set; }
     public string ConnectionString { get; set; }
    }
