    interface IMC2211Command
    {
    	void Run( object[] args );
    }
    
    class ReadByteCmd : IMC2211Command
    {
    	public void Run( object[] args )
    	{
    		// read bytes
    	}
    }
    
    class WriteByteCmd : IMC2211Command
    {
    	public void Run( object[] args )
    	{
    		// write bytes
    	}
    }
