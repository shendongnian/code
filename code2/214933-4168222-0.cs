    class ZClient
    {
        public ZClient(TcpClient client) 
        {
            this.client = client;
        }
        public TcpClient client {get; set;}
        public byte[] Buffer { get; set; }
        public Queue<byte[]> Queue {get; set;}
    }
