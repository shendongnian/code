    using System;
    using System.Net;
    using System.Net.Sockets;
    
    /*
       This program creates TCP server socket. Then a large number of clients tries to connect it.
       Server counts connected clients. The number of successfully connected clients depends on the BACKLOG_SIZE parameter.
     */
    
    
    namespace BacklogTest
    {
        class Program
        {
            private const int BACKLOG_SIZE = 0; //<<< Change this to 10, 20 ... 100 and see what happens!!!!
            private const int PORT = 12345;
            private const int maxClients = 100;
            
            private static Socket serverSocket;
            private static int clientCounter = 0;
            
            private static void AcceptCallback(IAsyncResult ar)
            {
                // Get the socket that handles the client request
                Socket listener = (Socket) ar.AsyncState;
                listener.EndAccept(ar);
                ++clientCounter;
                Console.WriteLine("Connected clients count: " + clientCounter.ToString() + " of " + maxClients.ToString());
                
                // do other some work
                for (int i = 0; i < 100000; ++i)
                {
                }
    
                listener.BeginAccept(AcceptCallback, listener);
            }
    
            private static void StartServer()
            {
                // Establish the locel endpoint for the socket
                IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, PORT);
    
                // Create a TCP/IP socket
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    
                // Bind the socket to the local endpoint and listen
                serverSocket.Bind(localEndPoint);
                serverSocket.Listen(BACKLOG_SIZE);
                serverSocket.BeginAccept(AcceptCallback, serverSocket);
            }
    
            static void Main(string[] args)
            {
                StartServer();
    
                // Clients connect to the server.
                for (int i = 0; i < 100; ++i)
                {
                    IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, PORT);
    
                    // Create a TCP/IP socket and connect to the server
                    Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    client.BeginConnect(remoteEP, null, null);
                }
    
                Console.ReadKey();
            }
        }
    }
