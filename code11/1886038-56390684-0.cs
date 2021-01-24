        public class MyTelemetryProcessor : ITelemetryProcessor
        {
            private ITelemetryProcessor Next { get; set; }
    
            public MyTelemetryProcessor(ITelemetryProcessor next)
            {
                this.Next = next;
            }
    
            public void Process(ITelemetry telemetry)
            {
                if (!(telemetry is EventTelemetry))
                {
                    //if it's not EventTelemetry, abandon it
                    return;
                }
    
                this.Next.Process(telemetry);
            }
        }
