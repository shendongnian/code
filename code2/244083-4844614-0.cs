    /*
    C# Network Programming 
    by Richard Blum
    
    Publisher: Sybex 
    ISBN: 0782141765
    */
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    
    public class UdpSrvrSample
    {
       public static void Main()
       {
          byte[] data = new byte[1024];
          IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
          UdpClient newsock = new UdpClient(ipep);
    
          Console.WriteLine("Waiting for a client...");
    
          IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
    
          data = newsock.Receive(ref sender);
    
          Console.WriteLine("Message received from {0}:", sender.ToString());
          Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));
    
          string welcome = "Welcome to my test server";
          data = Encoding.ASCII.GetBytes(welcome);
          newsock.Send(data, data.Length, sender);
    
          while(true)
          {
             data = newsock.Receive(ref sender);
           
             Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));
             newsock.Send(data, data.Length, sender);
          }
       }
    }
