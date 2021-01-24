    static void Main(string[] args)
    {
        IPAddress hostIP = Dns.GetHostAddresses("127.0.0.1")[0];
        List<TcpListener> listeners = new List<TcpListener>()
        {
            new TcpListener(hostIP, 6060),
            new TcpListener(hostIP, 6061)
        };
        var listenerTasks = listeners.Select(x => RunTcpListener(x)).ToArray();
        Task.WaitAll(listenerTasks);
    }
    private static async Task RunTcpListener(TcpListener listener)
    {
        listener.Start();
        try
        {
            while (true)
            {
                using (var client = await listener.AcceptTcpClientAsync())
                {
                    var stream = client.GetStream();
                    byte[] bytes = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
                    stream.Write(bytes, 0, bytes.Length);
                    client.Close();
                }
            }
        }
        finally
        {
            listener.Stop();
        }
    }
