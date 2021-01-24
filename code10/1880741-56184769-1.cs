        static async Task Main(string[] args)
        {
            var server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
	        server.Bind(new IPEndPoint(IPAddress.Any, 80));
            server.Listen(5);            
            while (true)
            {
		        var client = await server.AcceptAsync();
	            var backTask = ProcessClient(client); 
            }  
        }
        private static async Task ProcessClient(Socket socket)
        {
	        using (socket)
            {
                var ip = ((IPEndPoint)(socket.RemoteEndPoint)).Address;
                Console.WriteLine($"{ip} has connected!");
                var buffer = Encoding.Unicode.GetBytes("test");
                await socket.SendAsync(buffer, SocketFlags.None);
            }
            Console.WriteLine("Connection closed.");            
        }
