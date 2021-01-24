    public class MyTelemetryProcessor: ITelemetryProcessor
    {
        private ITelemetryProcessor Next { get; set; }
    
        public MyTelemetryProcessor(ITelemetryProcessor next)
        {
            this.Next = next;
        }
    
        public void Process(ITelemetry telemetry)
        {
    
            ExceptionTelemetry err1 = telemetry as ExceptionTelemetry;
            
            //you can use exception type or the error message to filter
            if(err1 !=null && err1.Exception.GetType().ToString().Contains("the exception type you want to filter"))
            {
                return;
            }
    
            if (err1 == null)
            {
                this.Next.Process(telemetry);
    
            }
    
            if (err1 != null)
            {
                this.Next.Process(err1);
            }
        }
    }
