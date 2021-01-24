    public class Process
    {
    	private Action<Result> CaptureFinished = null;
    	private Action<Result> CaptureSniffed = null;
    	private Sniffer _sniffer;
    
    	public Process(Sniffer sniffer)
    	{
    		_sniffer = sniffer; 							//1. INJECTION
    		CaptureSniffed = sniffer.CaptureFinishedSniffed;//2.Plumbing with the delegate
    	}
    
    	public Result StartProcess(Action<Result> onCaptureFinished)
    	{
    		CaptureFinished = onCaptureFinished;
    		...
    		CaptureFinished.Invoke(result);
    		CaptureSniffed.Invoke(result);					//3.Invoking
    		return new Result("OK");
    	}
    }
