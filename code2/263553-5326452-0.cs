    class Program
    {
        public static ManualResetEvent connected = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int port = 14500;
            TcpListener server = new TcpListener(IPAddress.Parse(ip), port);
            server.Start();
            Console.WriteLine("Server started...");
            while (true)
            {
                connected.Reset();
                server.BeginAcceptTcpClient(new AsyncCallback(AcceptCallback), server);
                connected.WaitOne();
            }
        }
        public static void AcceptCallback(IAsyncResult ar)
        {
            TcpListener listener = (TcpListener)ar.AsyncState;
            TcpClient client = listener.EndAcceptTcpClient(ar);
            byte[] buffer = new byte[1024];
            NetworkStream ns = client.GetStream();
            if (ns.CanRead)
            {
                ns.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReadCallback), new object[] { ns, buffer });
            }
            connected.Set();
        }
        public static void ReadCallback(IAsyncResult ar)
        {
            NetworkStream ns = (NetworkStream)((ar.AsyncState as object[])[0]);
            byte[] buffer = (byte[])((ar.AsyncState as object[])[1]);
            int n = ns.EndRead(ar);
            if (n > 0)
            {
                Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, n));
            }
            ns.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReadCallback), new object[] { ns, buffer });
        }
    }
