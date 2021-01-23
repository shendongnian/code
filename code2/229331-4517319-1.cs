    using System;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.IO;
    
    class SocketClient
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient;
            NetworkStream networkStream;
            StreamWriter streamWriter;
    
            try
            {
                tcpClient = new TcpClient("localhost", 5555);
                networkStream = tcpClient.GetStream();
    
                streamWriter = new StreamWriter(networkStream);
                while (true)
                {
                    streamWriter.WriteLine(Console.ReadLine());
                    streamWriter.Flush();
                    Console.WriteLine(streamReader.ReadLine());
                }
                Console.Read();
            }
            catch (SocketException ex){
                Console.WriteLine(ex);
            }
    
        }
    }
