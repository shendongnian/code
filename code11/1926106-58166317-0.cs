    public class Sniffer
    {
    	public Action<Result> CaptureFinishedSniffed;
    
    	public Sniffer()
    	{
    		CaptureFinishedSniffed = Captured;
    	}
    
    	public void Captured(Result result)
    	{
    		Console.WriteLine("Proper sniffer I have: {0}", result);
    	}
    }
