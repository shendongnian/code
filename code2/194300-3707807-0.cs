    	static void Main(string[] args)
		{
			TcpReceiveMiniServer server = new TcpReceiveMiniServer(8789);
			server.Start();
			server.DataArrived += new TcpReceiveMiniServer.DataArrivedHandler(server_DataArrived);
			Console.Read();
		}
		static void server_DataArrived(object sender, DataArrivedEventArgs e)
		{
			// do something with e.Data
		}
