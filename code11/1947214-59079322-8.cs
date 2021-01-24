    public class TcpConnection
    {
       object _lock = new object();
       bool _is_busy = false;
       public bool TakeLock()
       {
          lock (_lock)
          {
                if (_is_busy)
                {
                   return false;
                }
                else
                {
                   _is_busy = true;
                   return true;
                }
          }
       }
       public void ReleaseLock()
       {
          _is_busy = false;
       }
       public bool Connected { get; set; }
       public string ConnError { get; set; }
       public Socket client { get; set; }
       public Stream stream { get; set; }
       public BinaryWriter bw { get; set; }
       public DateTime LastUsed { get; set; }
       public int Index { get; set; }
       public TcpConnection(string hostname, int port)
       {
          client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    
          client.Connect(new IPEndPoint(IPAddress.Parse(hostname), port));
          if (client.Connected)
          {
    #if (VERBOSE)
                Console.WriteLine("Connected immediately");
    #endif
                //client.NoDelay = true;
                client.ReceiveTimeout = 60000;
                client.SendTimeout = 60000;
                this.stream = new NetworkStream(client);
                this.bw = new BinaryWriter(stream);
          }
          _is_busy = true;
          LastUsed = DateTime.Now;
       }
    }
