        public void Process(ITelemetry item)
        {
            if (item is ExceptionTelemetry exceptionTelemetry
                && other_condition)
            {
                // Track exception as warning instead
                var traceTelemetry = new TraceTelemetry(exceptionTelemetry.Exception.Message, SeverityLevel.Warning);
                
                //add this line of code to send the trace message.
                new TelemetryClient().TrackTrace(traceTelemetry);
                
                //Note that, you should remove the Next.Process() method here, or it will reproduce another same message with the above line of code
                //Next.Process(traceTelemetry);
            }
            else
            {
                Next.Process(item);
            }
        }
