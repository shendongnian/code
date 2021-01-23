        class MyClass
        {
        	
        
           
    
     System.Timers.Timer m_ConnectTimer = null;
        	
        	..
        	..
    
    	void ConnecToServer()
    	{
    		if (m_ConnectTimer != null)
    		{
    			m_ConnectTimer.Enabled = false;
    			m_ConnectTimer.Dispose();
    			m_ConnectTimer = null;
    		}
    
    		//Try to connect to the server
    		
    		if (bConnectedToTheServer)
    		{
    			//Do the servery stuff
    		}
    		else //set the timer again
    		{
    			m_ConnectTimer = new Timer(30 * 60 * 1000);
    			m_ConnectTimer.Elapsed += new ElapsedEventHandler(TimerHandler)
    			m_ConnectTimer.Enabled = true;
    		}
    
    	}
    
    
    	void TimerHandler(object sender, ElapsedEventArgs e)
    	{
    		ConnectToServer();
    	}
    	
    }
