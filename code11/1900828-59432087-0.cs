`
using System;
using NetMQ;
using NetMQ.Sockets;
class Program
{
    private static void Main()
    { 
        using (var server = new ResponseSocket("@tcp://*:11000"))
        {
            // the server receives, then sends
            Console.WriteLine("From Client: {0}", server.ReceiveFrameString());
            server.SendFrame("Hi Back");
            Console.ReadKey();
        }
    }
}
`
My Client code runs on my PC:
`
using System;
using NetMQ;
using NetMQ.Sockets;
class Program
{
    private static void Main()
    {
        using (var client = new RequestSocket(">tcp://3.13.186.250:11000"))
        {
            client.SendFrame("Hello");
            Console.WriteLine("From Server: {0}", client.ReceiveFrameString());
            Console.ReadKey();
        }
    }
}
`
