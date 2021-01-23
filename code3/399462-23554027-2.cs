    /// <summary>
    /// Handles the incoming socket message.
    /// </summary>
    private void HandleIncomingSocketMessage() {
    	if (_listener == null) return;
    	
    	while (true) {
    		Socket soc = _listener.AcceptSocket();
    		//soc.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 10000);
    		NetworkStream s = null;
    		StreamReader sr = null;
    		StreamWriter sw = null;
    		bool reading = true;
    		
    		if (soc == null) break;
    		
    		UnityEngine.Debug.Log("Connected: " + soc.RemoteEndPoint);
    		
    		try {
    			s = new NetworkStream(soc);
    			sr = new StreamReader(s, Encoding.Unicode);
    			sw = new StreamWriter(s, Encoding.Unicode);
    			sw.AutoFlush = true; // enable automatic flushing
    			
    			while (reading == true) {
    				string line = sr.ReadLine();
    				
    				if (line != null) {
    					//UnityEngine.Debug.Log("SOCKET MESSAGE: " + line);
    					UnityEngine.Debug.Log(line);
    					
    					lock (_threadLock) {
    						// Do stuff with your messages here
    					}
    				}
    			}
    
    			//
    		} catch (Exception e) {
    			if (s != null) s.Close();
    			if (soc != null) soc.Close();
    			UnityEngine.Debug.Log(e.Message);
    			//return;
    		} finally {
    
    		//
    		if (s != null) s.Close();
    		if (soc != null) soc.Close();
    		
    		UnityEngine.Debug.Log("Disconnected: " + soc.RemoteEndPoint);
    		}
    	}
    	
    	return;
    }
