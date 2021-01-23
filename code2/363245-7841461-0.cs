    class Buffer
    {
    	private readonly object syncObject = new object();
    	private readonly List<string> buffer = new List<string>();
    	
    	public void AddPacket(string packet)
    	{
    		lock (syncObject)
    		{
    			buffer.Add(packet);
    		}
    	}
    	
    	public void Notify()
    	{
    		// Do something, if needed lock again here
            // lock (syncObject)
            // {
            //     Notify Implementation
            // }
    	}
    }
