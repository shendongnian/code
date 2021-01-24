      public class MyTelemetryInitializer : ITelemetryInitializer
      {
    	public void Initialize(ITelemetry telemetry)
    	{
          telemetry.Properties["customuserid"] = "your_id";
        }
    
     }
