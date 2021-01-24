    public class MyTelemetryInitializer : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            //try to directly change the Timestamp, it changes successfully in local(in visual studio), but it does not send to application insights.
            telemetry.Timestamp = new DateTimeOffset(new DateTime(2020, 1, 10));
    
        }
     }
