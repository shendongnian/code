    public class Example
    {
        private BinaryTransport<Packet> _client;
        private ServerExample _server;
        public void Run()
        {
            // start server
            _server = new ServerExample();
            _server.Start(new IPEndPoint(IPAddress.Loopback, 1234));
            // start client
            _client = new BinaryTransport<Packet>(new IPEndPoint(IPAddress.Loopback, 1234));
            // send stuff from client to server
            _client.Send("Hello world!");
            // send custom object
            _client.Send(new User { FirstName = "Jonas", LastName = "Gauffin" });
        }
    }
    public class ServerExample
    {
        private readonly List<BinaryTransport<Packet>> _clients = new List<BinaryTransport<Packet>>();
        private SimpleServer _server;
        private void OnClientAccepted(Socket socket)
        {
            var client = new BinaryTransport<Packet>(socket);
            client.Disconnected += OnDisconnected;
            client.ObjectReceived += OnObject;
            _clients.Add(client);
        }
        private void OnDisconnected(object sender, EventArgs e)
        {
            var transport = (BinaryTransport<Packet>) sender;
            transport.Disconnected -= OnDisconnected;
            transport.ObjectReceived -= OnObject;
        }
        private void OnObject(object sender, ObjectEventArgs<Packet> e)
        {
            Console.WriteLine("We received: " + e.Object.Value);
        }
        public void Start(IPEndPoint listenAddress)
        {
            _server = new SimpleServer(listenAddress, OnClientAccepted);
            _server.Start(5);
        }
    }
    [Serializable]
    public class Packet
    {
        public object Value { get; set; }
    }
    [Serializable]
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
