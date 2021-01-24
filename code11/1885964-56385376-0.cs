        static void Main(string[] args)
        {
            IPAddress hostIP = Dns.GetHostAddresses("127.0.0.1")[0];
            List<TcpListener> listeners = new List<TcpListener>()
            {
                new TcpListener(hostIP, 6060),
                new TcpListener(hostIP, 6061)
            };
            ProcessConnections(listeners).Wait();
        }
        private static void SendData(Socket socket)
        {
            NetworkStream stream = new NetworkStream(socket);
            byte[] bytes = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
            stream.Write(bytes, 0, bytes.Length);
            socket.Close();
        }
        private static async Task ProcessConnections(List<TcpListener> listeners)
        {
            foreach (TcpListener listener in listeners)
            {
                listener.Start();
            }
            try
            { 
                List<Task<Socket>> tasks = new List<Task<Socket>>();
                foreach (TcpListener listener in listeners)
                {
                    tasks.Add(AcceptConnection(listener));
                }
                while (true)
                {
                    int i = Task.WaitAny(tasks.ToArray());
                    Socket socket = await tasks[i];
                    SendData(socket);
                    tasks.RemoveAt(i);
                    tasks.Insert(i, AcceptConnection(listeners[i]));
                }
            }
            finally
            {
                foreach (TcpListener listener in listeners)
                {
                    listener.Stop();
                }
            }
        }
        private static async Task<Socket> AcceptConnection(TcpListener listener)
        {
            Socket socket = await listener.AcceptSocketAsync();
            return socket;
        }
