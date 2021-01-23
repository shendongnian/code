    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading;
    using MySharedHouse;
    
    namespace ServerApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                MessageServer s = new MessageServer(515);
                s.Start();
            }
        }
    
        public class MessageServer
        {
            private int _port;
            private TcpListener _tcpListener;
            private bool _running;
            private TcpClient connectedTcpClient;
            private BinaryFormatter _bFormatter;
            private Thread _connectionThread;
    
            public MessageServer(int port)
            {
                this._port = port;
                this._tcpListener = new TcpListener(IPAddress.Loopback, port);
                this._bFormatter = new BinaryFormatter();
            }
    
            public void Start()
            {
                if (!_running)
                {
                    this._tcpListener.Start();
                    Console.WriteLine("Waiting for a connection... ");
                    this._running = true;
                    this._connectionThread = new Thread
                        (new ThreadStart(ListenForClientConnections));
                    this._connectionThread.Start();
                }
            }
    
            public void Stop()
            {
                if (this._running)
                {
                    this._tcpListener.Stop();
                    this._running = false;
                }
            }
    
            private void ListenForClientConnections()
            {
                while (this._running)
                {
                    this.connectedTcpClient = this._tcpListener.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    House house = new House();
                    house.Street = "Evergreen Terrace";
                    house.ZipCode = "71474";
                    house.Number = 742;
                    house.Id = 34527;
                    house.Town = "Springfield";
                    _bFormatter.Serialize(this.connectedTcpClient.GetStream(), house);
                    Console.WriteLine("send House!");
                }
            }
        }
    }
