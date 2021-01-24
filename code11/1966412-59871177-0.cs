        public class MyTelemetryInitializer : ITelemetryInitializer
        {
            public void Initialize(ITelemetry telemetry)
            {
                DateTimeOffset dateTimeOffset = new DateTimeOffset(new DateTime(2020, 1, 10));
                //define a custom property, which is a date time
                telemetry.Context.GlobalProperties["Custom_timestamp"] = dateTimeOffset.ToString();
    
            }
         }
