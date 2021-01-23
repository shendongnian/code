    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    
    namespace SocketServer
    {
        class Program
        {
            static void Main(string[] args)
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Any, 18001);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    
                socket.Bind(ip);
                socket.Listen(10);
                Console.WriteLine("Waiting for a client...");
                Socket client = socket.Accept();
                IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;
                Console.WriteLine("Connected with {0} at port {1}", clientep.Address, clientep.Port);
    
    
    
                string welcome = "HELLO 1 FROM SERVER";
                byte[] data = new byte[200];
                int receiveddata=client.Receive(data);
                Console.WriteLine("Received data from CLIENT1: {0}", System.Text.ASCIIEncoding.ASCII.GetString(data).Trim());
                
    
    
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] data2 = new byte[200];
                data2 = asen.GetBytes(welcome);
                int sentdata=client.Send(data2, data2.Length, SocketFlags.None);
                Console.WriteLine("Sent data from SERVER: {0}", welcome);
                
    
                
                byte[] data3 = new byte[200];
                Console.WriteLine("Receiving data from CLIENT : {0}", "...");
                client.Receive(data3);
    
    
                Console.WriteLine("Received data from CLIENT2: {0}", System.Text.ASCIIEncoding.ASCII.GetString(data3).Trim());
                byte[] data4 = new byte[200];
                data4 = asen.GetBytes("HELLO 2 FROM SERVER");
                sentdata = client.Send(data4, data4.Length, SocketFlags.None);
    
                client.Close();
                socket.Close();
    
    
                Console.WriteLine("Disconnected from {0}", clientep.Address);
    
                
    
                Console.ReadLine();
            }
        }
    }
