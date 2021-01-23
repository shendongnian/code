    using System;
    using System.IO;
    using System.Net.Sockets;
    
    class Program
    {
        static void Main()
        {
            using (var client = new TcpClient("www.google.com", 80))
            using (var stream = client.GetStream())
            using (var writer = new StreamWriter(stream))
            using (var reader = new StreamReader(stream))
            {
                writer.Write(
    @"GET / HTTP/1.1
    Host: www.google.com
    Connection: close
    
    ");
                writer.Flush();
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
