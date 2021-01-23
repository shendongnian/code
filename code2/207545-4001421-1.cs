	void Accept()
	{
		Console.WriteLine("Waiting for a connection...");
		listener.BeginAccept(AcceptCallback, listener);
	}
	public static void AcceptCallback(IAsyncResult ar) {
		Accept();
	
		//bla
	}
