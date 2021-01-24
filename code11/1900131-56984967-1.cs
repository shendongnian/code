	Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    TcpClient socket = new TcpClient();
	 
	if (TestWithTimeout(socket,"1.2.3.4",80,1))
	{
	//	....
	}	
	
     bool TestWithTimeout( Socket/TcpClient socket = new TcpClient(); socket, string host, int port, int timeout)
    {
    	Task result = socket.ConnectAsync(host, port);
    	Task.WaitAny(new[] { result }, timeout);
    	return socket.Connected;
    }
