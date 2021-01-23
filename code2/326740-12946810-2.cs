    namespace ZMQGuide
    {
        class Program
        {
            static void Main(string[] args)
            {
                // ZMQ Context, server socket
                using (Context context = new Context(1)
                using (Socket socket = context.Socket(SocketType.REP))
                {
                    socket.Bind("tcp://*:5555");
                    
                    while (true)
                    {
                        // Wait for next request from client
                        string message = socket.Recv(Encoding.Unicode);
                        Console.WriteLine("Received request: {0}", message);
    
                        // Do Some 'work'
                        Thread.Sleep(1000);
    
                        // Send reply back to client
                        socket.Send("World", Encoding.Unicode);
                    }
                }
            }
        }
    }
    
    namespace ZMQGuide
    {
        class Program
        {
            static void Main(string[] args)
            {
                // ZMQ Context and client socket
                using (Context context = new Context(1))
                using (Socket requester = context.Socket(SocketType.REQ))
                {
                    requester.Connect("tcp://localhost:5555");
    
                    string request = "Hello";
                    for (int requestNum = 0; requestNum < 10; requestNum++)
                    {
                        Console.WriteLine("Sending request {0}...", requestNum);
                        requester.Send(request, Encoding.Unicode);
    
                        string reply = requester.Recv(Encoding.Unicode);
                        Console.WriteLine("Received reply {0}: {1}", requestNum, reply);
                    }
                }
            }
        }
    }
