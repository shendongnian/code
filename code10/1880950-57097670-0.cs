    //Used to define what is returned in the async results
    public static CimAsyncMultipleResults<CimInstance> GetValues(CimSession _session)
    {
    	return _session.QueryInstancesAsync(@"root\cimv2", "WQL", "SELECT Username FROM Win32_ComputerSystem");
    }
    
    //This watches the async progress
    class CimInstanceWatcher : IObserver<CimInstance>
    {
    	public void OnCompleted()
    	{
    		Console.WriteLine("Done");
    	}
    
    	public void OnError(Exception e)
    	{
    		Console.WriteLine("Error: " + e.Message);
    	}
    
    	public void OnNext (CimInstance value)
    	{
    		Console.WriteLine("Value: " + value);
    	}
    }
    
    private static void Main()
    {
    	//Leaving cimsession creation as sync because is happens "instantly"
    	CimSession Session = CimSession.Create("PC-NAME");
        //Creating a new watcher object
    	var instanceObject = new CimInstanceWatcher();
        //Subscribing the watcher object to the async call
    	GetValues(Session).Subscribe(instanceObject);
    	Console.ReadLine();
    }
