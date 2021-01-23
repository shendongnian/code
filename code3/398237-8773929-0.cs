    interface IMessage 
    {
    	void Handle()
    	...	
    }
     
    class MessageFoo : IMessage
    {
    	void Handle()
    	{
    		//foo handle
    	}
    }
    
    class MessageBar : IMessage
    {
    	void Handle()
    	{
    		//bar handle
    	}
    }
