    namespace WpfApp1
    {
        public static class Telemetry
        {
            private const string TelemetryKey = "Your instrumentation key";
    
            public static TelemetryClient tc = new TelemetryClient() { InstrumentationKey=TelemetryKey};            
    
        }
    }
