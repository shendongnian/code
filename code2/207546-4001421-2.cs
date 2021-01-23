	void Accept()
	{
		Console.WriteLine("Waiting for a connection...");
		listener.BeginAccept(AcceptCallback, listener);
	}
	public static void AcceptCallback(IAsyncResult ar) {
                var listener = (Socket)ar.AsyncState;
                //Always call End async method or there will be a memory leak. (HRM)                
                listener.EndAccept(ar); 
		Accept();
	        
		//bla
	}
