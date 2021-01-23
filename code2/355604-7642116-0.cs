    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading;
    public static class Server
    {
        private static Thread _listenThread;
        public static IPEndPoint ServerEp { get; set; }
        private static TcpListener _listener;
        // Listens for clients and creates a new thread to talk to each client on
        private static void ListenMain()
        {
            /* Start Lisening */
            _listener = new TcpListener(ServerEp);
            _listener.Start();
            while (true)
            {
                TcpClient newClient = _listener.AcceptTcpClient();
                // Create a thread to handle client communication
                var clientThread = new Thread((ClientComm)) {IsBackground = true};
                clientThread.Start(newClient);
            }
        }
        // The Client Communcation Method
        private static void ClientComm(object clientobject)
        {
            TcpClient client = (TcpClient) clientobject;
            NetworkStream stream = client.GetStream();
            while (true)
            {
                try
                {
                    var message = RecieveMessage(client);
                    // process the message object as you see fit.
                }
                catch
                {
                    if (!client.Connected)
                    {
                        break;
                    }
                }
                // you could create a wrapper object for the connections
                // give each user a name or whatever and add the disconnect code here
            }
        }
        private static DataMessage RecieveMessage(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            IFormatter formatter = new BinaryFormatter();
            return (DataMessage)formatter.Deserialize(stream);
        }
        
        public static void SendMessage(DataMessage message, TcpClient client)
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(client.GetStream(), message);
        }
        // Starts...
        // You could add paramaters to this if you need to I like to set with Server.Etc
        public static void Start()
        {
            try
            {
                if (_listenThread.IsAlive) return;
            }
            catch (NullReferenceException)
            {
                _listenThread = new Thread(ListenMain) { IsBackground = true };
            }
            _listenThread.Start();
        }
    }
    // Must be in both client and server in a shared .dll
    // All properties must be serializable
    [Serializable]
    public class DataMessage
    {
        public string StringProp{ get; set; }
        public int IntProp { get; set; }
        public bool BoolProp { get; set; }
        // will cause an exception on serialization. TcpClient isn't marked as serializable.
      /*   public TcpClient Client { get; set; } */
    }
