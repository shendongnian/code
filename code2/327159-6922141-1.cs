    public class MockLoggingConfigurationProvider : ILoggingConfigurationProvider  {
       public MockLoggingConfigurationProvider() {
          // set both values to a test value
       }
     
       public string LogPath { get; set; }
       public string ConnectionString { get; set; }
    }
