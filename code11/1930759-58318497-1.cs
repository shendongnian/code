	public class tcpServer
	{
		public void method()
		{
			TcpListener server = new TcpListener(IPAddress.Any, 9999);
			server.Start();
			TcpClient client = server.AcceptTcpClient();
			NetworkStream ns = client.GetStream();
			byte[] hello = new byte[100];
			hello = Encoding.Default.GetBytes("hello world");
			while (client.Connected)
			{
				ns.Write(hello, 0, hello.Length); 
			}
		}
	}
