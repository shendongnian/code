    class MySqlConnection : IDatabaseConnection
    {
    	void IDatabaseConnection.connect()
    	{
    		//
    	}
    
    	void IDatabaseConnection.update()
    	{
    		(this as IDatabaseConnection).connect();
    	}
    }
