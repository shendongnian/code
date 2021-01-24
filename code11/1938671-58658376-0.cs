    using Microsoft.ApplicationInsights
    namespace MyNamesPace
    {
        public class MyClass
        {
            private readonly TelemetryClient _telemetryClient;
            public MyClass(TelemetryClient telemetryClient)
            {
                _telemetryClient= telemetryClient;
            }
            public myCassMethod()
            {
                // Use your _telemetryClient instance
                _telemetryClient.TrackEvent("Your Telemetry Event");
            }
        }
    }
    
