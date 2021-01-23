    void AcceptClient()
    {
    	// Create tcpListener here.
    	AcceptClientImpl(tcpListener);
    }
    
    void AcceptClientImpl(TcpListener tcpListener)
    {
    	Task.Factory.FromAsync<TcpClient>(tcpListener.BeginAcceptTcpClient, tcpListener.EndAcceptTcpClient, tcpListener).ContinueWith(antecedent =>
    	{
    		ConnectionAccepted(antecedent.Result);
    		// Restart task by calling AcceptClientImpl "recursively".
    		// Note, this is called from the thread pool. So no stack overflows.
    		AcceptClientImpl(tcpListener);
    	});
    }
    
    void ConnectionAccepted(TcpClient tcpClient)
    {
    	// Do stuff here.
    }
