    public class MyLibraryClass
    {
    	TelemetryClient _telemetryClient
    	
    	public MyLibraryClass(TelemetryClient telemetryClient)
    	{
    		_telemetryClient = telemetryClient;		
    	}	
    	
    	public void Foo()
    	{
    		_telemetryClient.TrackTrace("Foo");
    	}
    }
