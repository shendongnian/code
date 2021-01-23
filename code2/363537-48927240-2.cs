    using System;
    using System.Net.Sockets;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading;
    using MySharedHouse;
    
    namespace ClientApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                MessageClient client = new MessageClient(515);
                client.StartListening();
            }
        }
    
        public class MessageClient
        {
            private int _port;
            private TcpClient _tcpClient;
            private BinaryFormatter _bFormatter;
            private Thread _listenThread;
            private bool _running;
            private House house;
    
            public MessageClient(int port)
            {
                this._port = port;
                this._tcpClient = new TcpClient("127.0.0.1", port);
                this._bFormatter = new BinaryFormatter();
                this._running = false;
            }
    
            public void StartListening()
            {
                lock (this)
                {
                    if (!_running)
                    {
                        this._running = true;
                        this._listenThread = new Thread
                            (new ThreadStart(ListenForMessage));
                        this._listenThread.Start();
                    }
                    else
                    {
                        this._running = true;
                        this._listenThread = new Thread
                            (new ThreadStart(ListenForMessage));
                        this._listenThread.Start();
                    }
                }
            }
    
            private void ListenForMessage()
            {
                Console.WriteLine("Reading...");
                try
                {
                    while (this._running)
                    {
                        this.house = (House)this._bFormatter.Deserialize(this._tcpClient.GetStream());
                        Console.WriteLine(this.house.Street);
                        Console.WriteLine(this.house.ZipCode);
                        Console.WriteLine(this.house.Number);
                        Console.WriteLine(this.house.Id);
                        Console.WriteLine(this.house.Town);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.ReadLine();
                }
            }
        }
    }
