    class HandlingManager
    {
    	void HandleMessage(IMessage m)
    	{
    		m.Handle(); //knows which concrete type
    	}
    }
