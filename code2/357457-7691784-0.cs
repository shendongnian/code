    static Semaphore Go = new Semaphore(0, 1);
    static void Server()
    {
        TcpListener server = new TcpListener(22320);
        server.Start();
        Go.Release();
        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            new Thread((x) => ServerTask(x)).Start(client);
        }
    }
    static void ServerTask(object clnObj)
    {
        TcpClient client = clnObj as TcpClient;
        BinaryReader br = new BinaryReader(client.GetStream());
        BinaryWriter bw = new BinaryWriter(client.GetStream());
        string s = "FromServer: " + br.ReadString();
        bw.Write(s);
        client.Close();
    }
    static void Client(int i)
    {
            
        TcpClient client = new TcpClient();
        client.Connect("localhost", 22320);
        BinaryReader br = new BinaryReader(client.GetStream());
        BinaryWriter bw = new BinaryWriter(client.GetStream());
        bw.Write(i.ToString());
        Console.WriteLine(br.ReadString());
        client.Close();
            
    }
    static void Main(string[] args)
    {
        Thread t = new Thread(() => Server());
        t.IsBackground = true;
        t.Start();
        Go.WaitOne();
        Console.WriteLine("Server Started....");
        Parallel.For(0, 21, (i) => Client(i));
        Console.WriteLine("Clients Processed");
        Console.ReadLine();
    }
