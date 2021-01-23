	static void Main(string[] args) {
		Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		listenSocket.Bind(new IPEndPoint(IPAddress.Loopback, 4444));
		listenSocket.Listen(100);
		SocketAsyncEventArgs e = new SocketAsyncEventArgs();
		e.Completed += AcceptCallback;
		if (!listenSocket.AcceptAsync(e)) {
			AcceptCallback(listenSocket, e);
		}
		Console.ReadKey(true);
	}
	private static void AcceptCallback(object sender, SocketAsyncEventArgs e) {
		Socket listenSocket = (Socket)sender;
		do {
			try {
				Socket newSocket = e.AcceptSocket;
				Debug.Assert(newSocket != null);
				// do your magic here with the new socket
				newSocket.Send(Encoding.ASCII.GetBytes("Hello socket!"));
				newSocket.Disconnect(false);
				newSocket.Close();
			} catch {
				// handle any exceptions here;
			} finally {
				e.AcceptSocket = null; // to enable reuse
			}
		} while (!listenSocket.AcceptAsync(e));
	}
