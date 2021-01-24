    using System;
    using ZeroMQ;
    
    namespace ZeroMQ_Client
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var requester = new ZSocket(ZSocketType.REQ))
                {
                    // Connect
                    requester.Connect("tcp://127.0.0.1:5555");
    
                    for (int n = 0; n < 10; ++n)
                    {
                        string requestText = "Hello";
                        Console.Write("Sending {0}...", requestText);
    
                        // Send
                        requester.Send(new ZFrame(requestText));
    
                        // Receive
                        using (ZFrame reply = requester.ReceiveFrame())
                        {
                            Console.WriteLine(" Received: {0} {1}!", requestText, reply.ReadString());
                        }
                    }
                }
            }
        }
    }
