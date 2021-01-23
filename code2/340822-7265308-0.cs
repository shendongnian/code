    private void SendPing()
    {
    	// ...
    	Ping pingSender = new Ping();
    	pingSender.PingCompleted +=
                 new PingCompletedEventHandler(PingCompletedCallback);
    	// the async methods don't block,
        // and execution will continue after the following call
        pingSender.SendAsync(address, userToken);
    	// ...
    }
    
    private void PingCompletedCallback(object sender, PingCompletedEventArgs e)
    {
    	// ...
    	PingReply reply = e.Reply;
        object userToken = e.UserState;
    	// ...
    }
