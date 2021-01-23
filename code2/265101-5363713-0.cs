    static class Server
    {
        static Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    
        static void Main()
        {
            listener.Bind(new IPEndPoint(IPAddress.Any, 555));
            listener.BeginAccept(OnAccept, null);
            WaitUntilServerNeedsToShutdown () ;
            // worker threads will die because they are background
        }
    
        private static void OnAccept(IAsyncResult ar)
        {
            new Receiver(listener.EndAccept(ar));
            listener.BeginAccept(OnAccept, null);
        }
    }
    
    class Receiver
    {
        Socket socket;
        byte[] buffer = new byte[1024];
    
        public Receiver(Socket socket)
        {
            this.socket = socket;
            socket.BeginReceive(buffer, 0, 1024, SocketFlags.None, OnReceive, null);
        }
    
        private void OnReceive(IAsyncResult ar)
        {
            int received = socket.EndReceive(ar);
            byte[] toProcess = new byte[received];
            Buffer.BlockCopy(buffer, 0, toProcess, 0, received);
            // TODO: detect EOF and error conditions
            socket.BeginReceive(buffer, 0, 1024, SocketFlags.None, OnReceive, null);
            // TODO: is it OK to process incomplete data?
            Process(toProcess);
        }
    }
